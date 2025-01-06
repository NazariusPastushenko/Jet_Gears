using System.Collections.Generic;
using System.Drawing;

namespace Jet_Gears.Objects;

public class OverviewPart
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Manufacturer { get; set; }
    public string Article { get; set; }
    public string Brand_PictureURL { get; set; }
    public string Part_PictureURL { get; set; }
    public string Price { get; set; }
    public List<KeyValuePair<string, string>> Table { get; set; }

    public OverviewPart(string title, string description, string manufacturer, string article, string brandPictureUrl, string partPictureUrl, string price, List<KeyValuePair<string, string>> table)
    {
        Title = title;
        Description = description;
        Manufacturer = manufacturer;
        Article = article;
        Brand_PictureURL = brandPictureUrl;
        Part_PictureURL = partPictureUrl;
        Price = price;
        Table = table;
    }

    public override string ToString()
    {
        return Title + Description + Price;
    }
}