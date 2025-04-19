namespace Jet_Gears.Objects;

public class AutoZvuk_Maker
{
    public string Href { get; set; }
    public string Title { get; set; }
    
    public string ImgLink { get; set; }

    public AutoZvuk_Maker(string href, string title,  string imgLink)
    {
        Href = href;
        Title = title;
        ImgLink = imgLink;
    }

}