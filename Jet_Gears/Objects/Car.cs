namespace Jet_Gears.Objects;

public class Car
{
    public string Href { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }

    public Car(string href, string title, string subTitle)
    {
        Href = href;
        Title = title;
        SubTitle = subTitle;
    }
}