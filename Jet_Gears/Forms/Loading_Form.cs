using System.Drawing;
using System.Windows.Forms;

namespace Jet_Gears.Forms;

public partial class Loading_Form : Form
{
    public Loading_Form()
    {
        InitializeComponent();
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.None;
        this.ControlBox = false;
        this.ShowInTaskbar = false;
        this.TopMost = true;
        this.BackColor = Color.White;

        Label label = new Label
        {
            Text = "Завантаження...",
            Font = new Font("Bahnschrift SemiBold SemiConden", 15, FontStyle.Bold),
            AutoSize = true,
            Location = new Point(50, 50)
        };

        this.Controls.Add(label);
        this.Size = new Size(200, 100);
    }
}
