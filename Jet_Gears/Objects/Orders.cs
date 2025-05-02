using System.Collections.Generic;
using System.Drawing;
using System.Net.Mime;

namespace Jet_Gears.Objects;

public class Order(int orderId, string date, string price, List<OrderDetail> orderDetails)
{
    public int OrderId  { get; set; } = orderId;
    public string Date { get; set; } = date;
    public string Price { get; set; } = price;
    public List<OrderDetail> OrderDetails { get; set; } = orderDetails;
}

public class OrderDetail(string gearCode, string maker, int countOf, string gearPrice, string description,Image picture)
{
    public string GearCode { get; set; } = gearCode;
    public string Maker { get; set; } = maker;
    public int CountOf { get; set; } = countOf;
    public string GearPrice { get; set; } = gearPrice;
    public string Description { get; set; } = description;
    
    public Image Picture { get; set; } = picture;
}