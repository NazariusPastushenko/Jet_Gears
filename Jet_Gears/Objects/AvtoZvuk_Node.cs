using System.Collections.Generic;

namespace Jet_Gears.Objects;

public class AvtoZvuk_Node
{
    
    public string Title { get; set; }
    public string CategoryImageUrl { get; set; }
    public List<PartItem> Parts { get; set; }

    public AvtoZvuk_Node(string title, string categoryImageUrl)
    {
        Title = title;
        CategoryImageUrl = categoryImageUrl;
        Parts = new List<PartItem>();
    }

    public override string ToString()
    {
        string partsList = string.Join("\n", Parts);
        return $"🔧 {Title}\n📷 {CategoryImageUrl}\n{partsList}";
    }

    
    
    
    
    
    public class PartItem
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Link { get; set; }

        public PartItem(string name, string imageUrl, string link)
        {
            Name = name;
            ImageUrl = imageUrl;
            Link = link;
        }

        public override string ToString() =>
            $"• {Name}\n  🖼 {ImageUrl}\n  🌐 {Link}";
    }
    
       
    
}