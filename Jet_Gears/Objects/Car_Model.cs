namespace Jet_Gears.Objects;

public class Car_Model
{
    public string Href { get; set; }
    public string Title { get; set; }
    public string ImgUrl { get; set; }

    public Car_Model(string href, string title, string imgUrl)
    {
        Href = href;
        Title = title;
        ImgUrl = imgUrl;
    }
}