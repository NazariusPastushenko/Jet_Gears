using System.Collections.Generic;
using System.Drawing;

namespace Jet_Gears.Objects;

public class OverviewPart
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Image Brand_Picture { get; set; }
    public Image Part_Picture { get; set; }
    public string Price { get; set; }
    public List<KeyValuePair<string, string>> Table { get; set; }


    public OverviewPart(string title, string description, Image brandPicture, Image partPicture, string price, List<KeyValuePair<string, string>> table)
    {
        Title = title;
        Description = description;
        Brand_Picture = brandPicture;
        Part_Picture = partPicture;
        Price = price;
        Table = table;
    }

    public override string ToString()
    {
        return Title + Description + Price;
    }
}