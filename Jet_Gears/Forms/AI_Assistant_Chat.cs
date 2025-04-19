using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jet_Gears.Controls;
using Jet_Gears.DataBases;

namespace Jet_Gears.Forms;

public partial class AI_Assistant_Chat : Form
{
    private GeminiClient client = new GeminiClient("AIzaSyBPf8qu72sUFOE5NvyP7QGv7UpaC6Ud6YE");
    private int latest_y;
    private string response;
    public AI_Assistant_Chat(string prompt)
    {
        
        InitializeComponent();
        client.GetCompletion("Ти дуже крутий асистент для допомоги в ремонті автомобілів, тобі будуть задавати питання про автомобілі, надавай детальні відповіді лише на українській мові");
        if (prompt != "")
        {
            textBox1.Text = prompt;
            Send_Message_Button_Click(null, EventArgs.Empty);
        }
    }


    private void Create_User_Message(string text)
    {
        var msg = new ChatMessageControl(text, 550, ChatMessageControl.SenderType.User);
        msg.Width = 550;
        msg.Location = new Point(Chat_Panel.Width - msg.Width - 20, latest_y);
    
        Chat_Panel.Controls.Add(msg);
        msg.Show();
        Chat_Panel.PerformLayout(); // Заставляємо перерахувати розміри

        latest_y += msg.Height + 10;
    }

    private void Create_Assistant_Message(string text)
    {
        var msg = new ChatMessageControl(text, 900, ChatMessageControl.SenderType.Assistant);
        msg.Width = 550;
        msg.Location = new Point(20, latest_y);
    
        Chat_Panel.Controls.Add(msg);
        msg.Show();
        Chat_Panel.PerformLayout(); // Так само змушуємо перерахувати розмір

        latest_y += msg.Height + 10;
    }

    private async void Send_Message_Button_Click(object sender, EventArgs e)
    {

        string prompt = textBox1.Text;
        textBox1.Clear(); // очищення після відправки
        Chat_Panel.Controls.Clear();
        latest_y = 0;
        if (string.IsNullOrWhiteSpace(prompt))
        {
            MessageBox.Show("Ви не ввели повідомлення, повторіть спробу", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        Create_User_Message(prompt);
        // Очікуємо відповідь
        await Ask_Ai(prompt);
        Create_Assistant_Message(response);
    
        response = ""; // очищаємо після відображення
    }
    
    private async Task Ask_Ai(string prompt)
    {
        response = await client.GetCompletion(prompt);
        response = response.Replace("**", "");
    }
    
}