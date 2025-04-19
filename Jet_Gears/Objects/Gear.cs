using System.Drawing;
using System.Net.Mime;

namespace Jet_Gears.Objects
{
    public class Gear
    {
        public int id { get; set; }
        public string gear_code { get; set; }
        public int count_of { get; set; }
        public string maker { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public Image picture { get; set; }


        public Gear(string gearCode, int countOf, string maker, int price, string description, Image picture)
        {
            this.id = id;
            gear_code = gearCode;
            count_of = countOf;
            this.maker = maker;
            this.price = price;
            this.description = description;
            this.picture = picture;

        }

        
        public override string ToString()
        {
            return $"ID: {id}, Code: {gear_code}, Count: {count_of}, Make: {maker}, Price: {price}, Description: {description}";
        }
 
    } 
}