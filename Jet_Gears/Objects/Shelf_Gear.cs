using System.Drawing;

namespace Jet_Gears.Objects;

public class Shelf_Gear
{
    public string gearcode { get; set; }
    public string count_of { get; set; }
    public string maker { get; set; }
    public string price { get; set; }
    public string description { get; set; }
    public Image image { get; set; }

    public Shelf_Gear( string gearcode, string countOf, string maker, string price, string description, Image image)
    {
        this.gearcode = gearcode;
        count_of = countOf;
        this.maker = maker;
        this.price = price;
        this.description = description;
        this.image = image;
    }
}