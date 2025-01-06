using System.Drawing;

namespace Jet_Gears.Objects;

public class Shelf_Gear
{
    public int id { get; set; }
    public string gearcode { get; set; }
    public string count_of { get; set; }
    public string maker { get; set; }
    public string price { get; set; }
    public string description { get; set; }
    public Image image { get; set; }

    public Shelf_Gear(int id, string gearcode, string countOf, string maker, string price, string description, Image image)
    {
        this.id = id;
        this.gearcode = gearcode;
        count_of = countOf;
        this.maker = maker;
        this.price = price;
        this.description = description;
        this.image = image;
    }
}