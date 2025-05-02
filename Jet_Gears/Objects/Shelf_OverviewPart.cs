using System.Collections.Generic;
using System.Drawing;

namespace Jet_Gears.Objects;

public class Shelf_OverviewPart
{
    public string Title { get; set; }
    public int count_of { get; set; }
    public string Manufacturer { get; set; }
    public string Description { get; set; }
    
    public Image Part_Picture { get; set; }
    public string Article { get; set; }
    public string Price { get; set; }


    public Shelf_OverviewPart(string title, int countOf, string manufacturer, string description, Image partPicture, string article, string price)
    {
        Title = title;
        count_of = countOf;
        Manufacturer = manufacturer;
        Description = description;
        Part_Picture = partPicture;
        Article = article;
        Price = price;
    }

    public override string ToString()
    {
        return Title + Description + Price;
    }
}