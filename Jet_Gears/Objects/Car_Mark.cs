using System.Dynamic;

namespace Jet_Gears.Objects;

public class Car_Mark
{
    public string Href { get; set; }
    public string Title { get; set; }

    public Car_Mark(string href, string title)
    {
        Href = href;
        Title = title;
    }
}