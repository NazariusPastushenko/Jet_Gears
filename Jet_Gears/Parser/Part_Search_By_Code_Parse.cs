using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Net.Http;
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
    public static Search_Gear Part_Seach_Search(string url)
    {
        Search_Gear part = null;
        var i = 0;
        Console.OutputEncoding = Encoding.Unicode;
        Categories.Search_Gears.Clear();
        i++;
        var web = new HtmlWeb();
        try
        {
            var document = web.Load(url);
            var productCards = document.DocumentNode.SelectNodes("//div[@class='product-card__wrapper']");



            // Знаходимо всі елементи з класом product-card

            foreach (var productCard in productCards)
            {

                var titleNode = productCard.SelectSingleNode(".//div[@class='product-card__title']/a/text()");
                var title = titleNode?.InnerText.Trim();


                // Заголовок product-card__title
                var descriptionNode = productCard.SelectSingleNode(".//div[@class='product-card__subtitle']");
                var description = descriptionNode?.InnerText.Trim();


                // Інформація product-card__info
                var priceNode =
                    productCard.SelectSingleNode(
                        ".//div[@class='product-card__price']//div[@class='product-card__new-price']");
                var price = priceNode?.InnerText.Trim();


                var imageNode =
                    productCard.SelectSingleNode(".//div[@class='product-card__image']//img[@class='lazyload']");
                var imageURL = imageNode?.Attributes["src"]?.Value.Trim();

                // Очистка від зайвих символів нового рядка
                description = CleanText(description);
                price = CleanText(price);
                price = price.Remove(0, 8);

                // Виводимо зібрані дані
                
                Console.WriteLine($"Title: {title}");
                Console.WriteLine($"Description: {description}");
                Console.WriteLine($"Price: {price}");
                Console.WriteLine($"ImageURL: {imageURL}");
                Console.WriteLine(new string('-', 30));
                part = new Search_Gear(title, description, price, imageURL, "");
            
            }
        }
        catch (Exception e)
        {
            MessageBox.Show("", "Помилка", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            Console.WriteLine(e);
            return null;
        }
        return part;
    }

    static string CleanText(string text)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;

        // Замінюємо кілька пробілів чи нових рядків на один пробіл
        return Regex.Replace(text, @"\s+", " ").Trim();
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