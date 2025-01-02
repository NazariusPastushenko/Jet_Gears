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
    public async static Task Part_URL_Search(string url)
    {
        Console.OutputEncoding = Encoding.Unicode;
        var web = new HtmlWeb();
        try
        {
            var doc = web.Load(url);
            // Заголовок
            var TitleNode = doc.DocumentNode.SelectSingleNode("//div[@class='product__title']/h1");
            var Title = TitleNode?.SelectSingleNode(".//text()")?.InnerText.Trim();
            var DescriptionNode = TitleNode?.SelectSingleNode(".//span[@class='product__subtitle']");
            var Description = DescriptionNode?.InnerText.Trim();

            // Зображення
            var picturesNodes = doc.DocumentNode.SelectNodes("//div[@class='product__pictures']//img");
            var pictures = picturesNodes?.Select(node => node.GetAttributeValue("src", string.Empty)).ToList();

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
            Console.WriteLine("\nPictures:");
            if (pictures != null)
                pictures.ForEach(Console.WriteLine);

            Console.WriteLine("\nPrice:");
            Console.WriteLine(price);

            Console.WriteLine("\nTable:");
            foreach (var entry in tableData)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            Image brand_img = null;
            Image part_img = null;
            /*try
            {
                brand_img = await LoadImageFromUrlAsync(pictures[0]);
            }
            catch
            {
                MessageBox.Show("Картинка бренду недоступна", "Помилка", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            try
            {
                part_img = await LoadImageFromUrlAsync(pictures[1]);
            }
            catch
            {
                MessageBox.Show("Картинка деталі недоступна", "Помилка", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            */

            Categories.Current_Overview_Part = new OverviewPart(Title, Description, brand_img, part_img, price,tableData);
        }
        catch (Exception e)
        {
            {
                Console.WriteLine("Помилка зчитування деталі!!!!!");
            }
        }
    }



    private static async Task<Image> LoadImageFromUrlAsync(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            using (Stream stream = await response.Content.ReadAsStreamAsync())
            {
                return Image.FromStream(stream);
            }
        }
    }
}