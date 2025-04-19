using System;
using System.Text;
using System.Windows.Forms;

namespace Jet_Gears
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Enter_Form());
            Console.OutputEncoding = Encoding.UTF8;
        }
        
        public static void Ask_Closing(object sender, FormClosingEventArgs e)
        {
            // Проверяем, что окно закрывается пользователем (не через код)
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Ви впевнені що хочете припинити роботу?", 
                    "Підтвердження", MessageBoxButtons.YesNo);
        
                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Отменяем закрытие формы
                }
            }
        }
    }
}