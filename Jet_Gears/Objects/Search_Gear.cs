namespace Jet_Gears.Objects;

public class Search_Gear
{
    public string title { get; set; }
    public string description { get; set; }
    public string price { get; set; }
    public string ImgURL { get; set; }

    public Search_Gear(string title, string description, string price, string imgUrl)
    {
        this.title = title;
        this.description = description;
        this.price = price;
        ImgURL = imgUrl;
    }
}