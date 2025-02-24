using System.Collections.Generic;
using System.Linq;

namespace Jet_Gears.Objects;

public class AutoPart
{
    public string ImageUrl { get; set; }
    public string Name { get; set; }
    public string Link { get; set; }
}

public class Node
{
    public string ImageUrl { get; set; }
    public string Name { get; set; }
    public  List<AutoPart> Parts { get; set; }
    
    public  List<AutoPart> GetPartsByName(string partName)
    {
        return Parts.Where(part => part.Name == partName).ToList();
    }
    
    
}