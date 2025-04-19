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
            List<string> modelsArray = null;
            var modelTitles = doc.DocumentNode
                .SelectNodes("//div[contains(@class, 'compatibility__model-title')]")
                ?.Select(node => node.InnerText.Trim())
                .ToList();
            
            
            // Перевірка і вивід
            if (modelTitles != null)
            {
                modelsArray = modelTitles.ToList();
            }
            else
            {
                Console.WriteLine("Моделі не знайдено.");
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
            
            foreach (var model in modelsArray)
            {
                Console.WriteLine(model);
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
    
    
    public static void PartZvuk_URL_Search(string url)
    {
        Console.OutputEncoding = Encoding.Unicode;
        var web = new HtmlWeb();
            try
            {
                var document = web.Load(url);
                // Зображення товару (за допомогою XPath для атрибуту src)
                var imageNode = document.DocumentNode.SelectSingleNode("//div[@class='product-view-header__wrap-img']/a/img");
                var imageUrl = imageNode?.GetAttributeValue("data-src", imageNode?.GetAttributeValue("src", "none"));
                // Витягуємо назву з title-item
                var titleNode = document.DocumentNode.SelectSingleNode("//div[@class='g-container']/h1");
                var title = titleNode?.InnerText ?? "Немає назви";
                // Витягуємо ціну з price
                var priceNode = document.DocumentNode.SelectSingleNode(".//div[@class='product-view-prices__base-price-number']");
                var price = priceNode?.InnerText;
                var tableRows = document.DocumentNode.SelectNodes("//div[contains(@class, 'aside-main-table__tr')]");
                var tableData = new List<KeyValuePair<string, string>>();
        
                if (tableRows != null)
                {
                    foreach (var row in tableRows)
                    {
                        var cells = row.SelectNodes("div[contains(@class, 'aside-main-table__td')]");
                
                        if (cells != null && cells.Count == 2)
                        {
                            string key = cells[0].InnerText.Trim();
                            string value = string.Join(", ", cells[1].SelectNodes(".//a")?.Select(a => a.InnerText.Trim()) ?? new List<string> { cells[1].InnerText.Trim() });
                    
                            tableData.Add(new KeyValuePair<string, string>(key, value));
                        }
                    }
                }
                
                Console.WriteLine($"Назва: {title}");
                Console.WriteLine($"Ціна: {price} грн");
                Console.WriteLine($"Зображення: {imageUrl}");
                string brand = "";
                foreach (var entry in tableData)
                {
                    Console.WriteLine($"{entry.Key}: {entry.Value}");
                    if (entry.Key == "Бренд")
                    {
                        brand = entry.Value;
                    }
                }
                
                string[] split_title = title.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                
                Categories.Current_OverviewPart = new OverviewPart(title,"",brand,split_title[split_title.Length-1],"",imageUrl,price + " \u20B4",tableData);
            }
            
            
            catch (Exception e)
            {

                Console.WriteLine("Помилка зчитування деталі");

            }
            
    }
    
}