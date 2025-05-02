using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Jet_Gears.Controls;
using Jet_Gears.DataBases;
using Jet_Gears.Objects;
using Jet_Gears.Properties;
using DateTime = System.DateTime;

namespace Jet_Gears.Forms;

public partial class HistoryForm : Form
{
    private DataBase _dataBase = new DataBase();
    
    private int _latestXShelf = 0;
    private int _latestYShelf = 0;
    
    public HistoryForm()
    {
        InitializeComponent();
        Read_Orders();
        dateTimePicker2.Value = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);
        dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month-1, DateTime.Now.Day);
        ShowCards(dateTimePicker1.Value,dateTimePicker2.Value);
    }

    private void ShowCards(DateTime value1, DateTime value2)
    {
        Delete_Cards();
        DateTime dateTime1 = new DateTime(value1.Year, value1.Month, value1.Day, 0, 1, 1,2);
        DateTime dateTime2 = new DateTime(value2.Year, value2.Month, value2.Day, 23, 59, 1,2);
        var filteredOrders = Categories.Orders.Where(order =>
        {
            if (DateTime.TryParse(order.Date, out DateTime orderDate))
            {
                return orderDate >= dateTime1 && orderDate <= dateTime2;
            }
            return false;
        }).ToList();
        
        
        List<Order> sortedOrders = filteredOrders
            .OrderByDescending(order => DateTime.ParseExact(order.Date, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture))
            .ToList();
        

        foreach (var Order in sortedOrders)
        {
            Create_Card(Order);
        }
    }
    
    private void Delete_Cards()
    {
        Card_Panel.Controls.Clear();
        _latestXShelf = 0;
        _latestYShelf = 0;
    }
    
    private void Create_Card(Order order)
    {
        GearCard card = new GearCard();
        card.BorderColor = Color.Black;
        card.Order_object = order;
        card.RoundedCorners = false;
        card.Location = new Point(_latestXShelf, _latestYShelf);
        card.Size = new Size(1150, 60);
        card.NameLabel = $"Замовлення номер {order.OrderId}";
        card.DescriptionLabel = $"Дата - {order.Date}";
        card.MainTextSize = 15;
        card.RightTextSize = 15;
        card.PriceLabel = $"Сума: {order.Price}";
        card.RightLabel2Text = "Кількість: " + order.OrderDetails.Count;


        card.RightBottomButtonSize = new Size(0, 0);
        card.RightTopButtonImage = Resources.Black_X;

        card.Click += CardClick;
        card.right_Top_Button_Click += Delete_Order;
            
        _latestYShelf = _latestYShelf + 10 + card.Height;
        Card_Panel.Controls.Add(card);
    }

    private void Delete_Order(object sender, EventArgs e)
    {
        try
        {
            GearCard card = sender as GearCard;
            Order order = card.Order_object;

            string querystring = @"DELETE FROM OrderDetails WHERE OrderID = @order_id";

            using SqlCommand command = new SqlCommand(querystring, _dataBase.getConnection());
            command.Parameters.AddWithValue("@order_id", order.OrderId);

            _dataBase.openConnection();

            int affectedRows = command.ExecuteNonQuery();
            if (affectedRows < 1) // може бути більше одного, якщо є кілька OrderDetails
            {
                MessageBox.Show("Не знайдено деталей замовлення для видалення.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Тепер видаляємо саме замовлення
            string quer = @"DELETE FROM Orders WHERE User_Token = @Token and Order_Id = @order_id";

            using SqlCommand cmd = new SqlCommand(quer, _dataBase.getConnection());
            cmd.Parameters.AddWithValue("@order_id", order.OrderId);
            cmd.Parameters.AddWithValue("@Token", Categories.CurrUserToken);

            int rows = cmd.ExecuteNonQuery();
            if (rows < 1)
            {
                MessageBox.Show("Замовлення не знайдено або вже було видалено.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Замовлення видалено з історії", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (SqlException ex)
        {
            MessageBox.Show("SQL помилка: " + ex.Message, "Помилка SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _dataBase.closeConnection();
            Categories.CurrentMainForm.OpenChildForm(new HistoryForm(),false);
        }
    }


    private void CardClick(object sender, EventArgs e)
    {
        GearCard card = sender as GearCard;
        Order order = card.Order_object;
        if (order.OrderDetails.Count == 0)
        {
            MessageBox.Show("В замовлені відсутні деталі.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        Categories.CurrentMainForm.OpenChildForm(new Order_Details_Form(order));
    }

    private void Read_Orders()
    {
        Categories.Orders.Clear();
        var token = Categories.CurrUserToken;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable ordersTable = new DataTable();

        string queryOrders = $"SELECT * FROM Orders WHERE User_Token = '{token}'";
        SqlCommand commandOrders = new SqlCommand(queryOrders,_dataBase.getConnection());

        adapter.SelectCommand = commandOrders;
        adapter.Fill(ordersTable);

        foreach (DataRow orderRow in ordersTable.Rows)
        {
            
            int orderId = Convert.ToInt32(orderRow["Order_Id"]);
            string date = orderRow["Date"].ToString();
            string price = orderRow["Price"].ToString();

            Order newOrder = new Order(orderId,date,price,new List<OrderDetail>());

            // Отримуємо деталі замовлення
            SqlDataAdapter detailsAdapter = new SqlDataAdapter();
            DataTable detailsTable = new DataTable();

            string queryDetails = $"SELECT * FROM OrderDetails WHERE OrderID = {orderId}";
            SqlCommand commandDetails = new SqlCommand(queryDetails,_dataBase.getConnection());

            detailsAdapter.SelectCommand = commandDetails;
            detailsAdapter.Fill(detailsTable);

            foreach (DataRow detailRow in detailsTable.Rows)
            {
                string gearCode = detailRow["GearCode"].ToString();
                string maker = detailRow["Maker"].ToString();
                int countOf = Convert.ToInt32(detailRow["CountOf"]);
                string gearPrice = detailRow["Price"].ToString();
                string description = detailRow["Description"].ToString();
                
                // Отримуємо картинку з колонки Picture
                Image image = null;
                if (detailRow["Picture"] != DBNull.Value)
                {
                    byte[] imageData = (byte[])detailRow["Picture"];
                    using MemoryStream ms = new MemoryStream(imageData);
                    image = Image.FromStream(ms);
                }

                newOrder.OrderDetails.Add(new OrderDetail(gearCode,maker, countOf, gearPrice, description,image));
            }
            Categories.Orders.Add(newOrder);
        }

    }

    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
        ShowCards(dateTimePicker1.Value,dateTimePicker2.Value);
    }

    private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
    {
        ShowCards(dateTimePicker1.Value,dateTimePicker2.Value);
    }
}