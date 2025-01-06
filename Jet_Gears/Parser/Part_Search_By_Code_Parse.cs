using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;
using HtmlAgilityPack;
using Jet_Gears;
using Jet_Gears.Objects;
using Newtonsoft.Json;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using GTranslate.Translators;
namespace Jet_Gears.Parser;

public class Part_Search_By_Code_Parse
{
    public static OverviewPart Part_URL_Search(string url)
    {
        OverviewPart Return_part = new OverviewPart("", "", "", "", "", "","",new List<KeyValuePair<string, string>>());
        var web = new HtmlWeb();
        try
        {
            var doc = web.Load(url);
            // Заголовок
            var TitleNode = doc.DocumentNode.SelectSingleNode("//div[@class='product__title']/h1");
            var Title = TitleNode?.SelectSingleNode(".//text()")?.InnerText.Trim();
            var DescriptionNode = TitleNode?.SelectSingleNode(".//span[@class='product__subtitle']");
            var Description = DescriptionNode?.InnerText.Trim();

            // Виробник деталі
            var manufacturerNode = doc.DocumentNode.SelectSingleNode("//div[@class='product__artkl']");
            var manufacturerText = manufacturerNode?.InnerText.Trim();
            var manufacturer = manufacturerText?.Split(new[] { "Manufacturer:" }, StringSplitOptions.None).LastOrDefault()?.Trim();

            
            // Зображення
            var picturesNodes = doc.DocumentNode.SelectNodes("//div[@class='product__pictures']//img");
            var pictures = picturesNodes?.Select(node => node.GetAttributeValue("src", string.Empty)).ToList();

            // Артикул
            var artklNode = doc.DocumentNode.SelectSingleNode("//div[@class='product__artkl']");
            var articleMatch = Regex.Match(artklNode?.InnerText ?? "", @"Article №:\s*([\w-]+)");
            var article = articleMatch.Success ? articleMatch.Groups[1].Value.Trim() : string.Empty;
            
            // Ціна
            var priceNode =
                doc.DocumentNode.SelectSingleNode("//div[@class='product__price']//div[@class='product__new-price']");
            var price = priceNode?.InnerText.Trim();

            // Таблиця
            var tableRows = doc.DocumentNode.SelectNodes("//table[@class='product__table']//tr");
            var tableData = new List<KeyValuePair<string, string>>();
            if (tableRows != null)
            {
                foreach (var row in tableRows)
                {
                    var cells = row.SelectNodes("td");
                    if (cells != null && cells.Count == 2)
                    {
                        var key = cells[0].InnerText.Trim();
                        var value = cells[1].InnerText.Trim();
                        tableData.Add(new KeyValuePair<string, string>(key, value));
                    }
                }
            }

            
            
            Console.WriteLine("Title:");
            Console.WriteLine(Title);
            Console.WriteLine("Description:");
            Console.WriteLine(Description);
            Console.WriteLine("Manufacturer:");
            Console.WriteLine(manufacturer);
            Console.WriteLine("Article:");
            Console.WriteLine(article);
            
            
            Console.WriteLine("\nPictures:");
            if (pictures != null)
                pictures.ForEach(Console.WriteLine);

            Console.WriteLine("\nPrice:");
            price = price.Remove(0, 8);
            Console.WriteLine(price);
            double priceUA = Convert.ToDouble(price) * 53.04;
            priceUA = (int)priceUA;
            Console.WriteLine("\nTable:");
            foreach (var entry in tableData)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            string brand_img = pictures[0];
            string part_img = pictures[1];



            Return_part = new OverviewPart(Title, Description, manufacturer,article,brand_img, part_img, priceUA.ToString(), tableData);
        }
        catch (Exception e)
        {

            Console.WriteLine("Помилка зчитування деталі!!!!!");

        }

        return Return_part;
    }
}