using System;
using System.Drawing;
using System.Windows.Forms;
using Jet_Gears.Controls;
using Jet_Gears.Objects;
using Jet_Gears.Properties;

namespace Jet_Gears.Forms;

public partial class Order_Details_Form : Form
{
    private Animation _slideAnimation;
    private readonly Timer _animationTimer;
    private readonly int _latestXShelf = 15;
    private int _latestYShelf = 0;
    private Order _order;
    public Order_Details_Form(Order order)
    {
        InitializeComponent();
        _order = order;
        DrawCards();
        _animationTimer = new Timer
        {
            Interval = 16 // 60 FPS (~16 мс на кадр)
        };
        _animationTimer.Tick += OnAnimationTick;
        KeyPreview = true;
    }

    private void DrawCards()
    {
        foreach (var detail in _order.OrderDetails)
        {
            GearCard card = new GearCard();
            card.BorderColor = Color.Black;
            card.Card_object = new Shelf_Gear(detail.GearCode,detail.CountOf.ToString(),detail.Maker,detail.GearPrice,detail.Description,detail.Picture,false);
            card.RoundedCorners = false;
            card.Location = new Point(_latestXShelf, _latestYShelf);
            card.Size = new Size(1150, 60);
            card.NameLabel = $"{detail.GearCode}";
            card.DescriptionLabel = $"";
            card.MainTextSize = 15;
            card.RightTextSize = 15;
            card.LeftImage = detail.Picture;
            card.PriceLabel = $"                Ціна: {detail.GearPrice}";
            card.RightLabel2Text = "Кількість: " + detail.CountOf;


            card.RightBottomButtonSize = new Size(0,0);
            card.RightBottomButtonSize = new Size(0,0);
            card.LeftImageMouseEnter += BusketCard_LeftImageMouseEnter;
            card.LeftImageMouseLeave += BusketCard_LeftImageMouseLeave;

            card.Click += CardClick;
            
            _latestYShelf = _latestYShelf + 10 + card.Height;
            panel1.Controls.Add(card);
        }
        
    }

    
    private Form activeForm = null;
        
        
    public void OpenChildFormWithAnimation(Form childForm)
    {
        if (activeForm != null)
        {
            activeForm.Close();
        }

        activeForm = childForm;
        childForm.TopLevel = false;
        childForm.FormBorderStyle = FormBorderStyle.None;
        childForm.Left = Width; // Початкова позиція за межами правої сторони
        childForm.Top = 0;
        childForm.Height = ClientSize.Height;
        childForm.Width = 500; // Ширина форми огляду
        Controls.Add(childForm);
        Controls.SetChildIndex(childForm, 0);

        _slideAnimation = new Animation(
            "SlideIn",
            () => childForm.Invalidate(),
            childForm.Left,
            Width - childForm.Width
        );

        _animationTimer.Start();
        childForm.Show();
    }
        
    private void OnAnimationTick(object sender, EventArgs e)
    {
        if (_slideAnimation.Status != Animation.AnimationStatus.Completed)
        {
            _slideAnimation.UpdateFrame();
            activeForm.Left = (int)_slideAnimation.Value;
        }
        else
        {
            _animationTimer.Stop();
        }
    }
    
    private void CardClick(object sender, EventArgs e)
    {
        GearCard card = sender as GearCard;
        Shelf_Gear item = card.Card_object;
        Shelf_OverviewPart shelfOverviewPart = new Shelf_OverviewPart(item.gearcode, int.Parse(item.count_of), item.maker,
            item.description, item.image, "", item.price.ToString());
        Shelf_OverviewGear_Form overviewGearForm = new Shelf_OverviewGear_Form(shelfOverviewPart,null,null);
        OpenChildFormWithAnimation(overviewGearForm);
    }

    private void BusketCard_LeftImageMouseEnter(object sender, EventArgs e)
    {
        GearCard card = sender as GearCard;

        Panel p = new Panel();
        p.BackgroundImage = card.LeftImage;
        p.BackgroundImageLayout = ImageLayout.Stretch;
        p.Size = new Size(300, 300);
        p.Location = new Point(80, 150);

        p.BorderStyle = BorderStyle.FixedSingle;
        Controls.Add(p);
        Controls.SetChildIndex(p, 0);
        p.Tag = "ZoomPicture";
        SuspendLayout();
    }

    private void BusketCard_LeftImageMouseLeave(object sender, EventArgs e)
    {
        foreach (Control c in Controls)
        {
            if (c.Tag == "ZoomPicture")
            {
                Controls.Remove(c);
            }
        }

        ResumeLayout();
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        Categories.CurrentMainForm.OpenChildForm(new HistoryForm(),false);
    }
}