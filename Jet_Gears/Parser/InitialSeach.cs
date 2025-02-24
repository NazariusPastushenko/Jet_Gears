using System;using System.Drawing.Drawing2D;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;
using GoogleTranslateFreeApi;
using HtmlAgilityPack;
using Jet_Gears;
using Jet_Gears.Objects;
using Newtonsoft.Json;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;


public class InitialSearch
{
    public static async void Initial_Search(string article,string type)
    {
        string url = "https://www.onlinecarparts.co.uk/spares-search.html?keyword=" + article;
        if (type == "Node")
        {
             url = article;
        }
        
        var i = 0;
        repeat:
        Console.OutputEncoding = Encoding.Unicode;
        Categories.SearchGears.Clear();
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
                var image = imageNode?.Attributes["src"]?.Value.Trim();

                var linkNode = productCard.SelectSingleNode(".//div[@class='product-card__title']/a");
                var link = linkNode?.Attributes["href"]?.Value; // Отримуємо атрибут href


                // Очистка від зайвих символів нового рядка
                description = CleanText(description);
                price = CleanText(price);
                price = price.Remove(0, 8); 
                double priceUA = Convert.ToDouble(price) * 53.04;
                priceUA = (int)priceUA;
                
                // Виводимо зібрані дані
                Console.WriteLine($"Title: {title}");
                Console.WriteLine($"Description: {description}");
                Console.WriteLine($"Price: {price}");
                Console.WriteLine($"ImageURL: {image}");
                Console.WriteLine($"URL: {link}");
                Console.WriteLine(new string('-', 30));


                Categories.SearchGears.Add(new Search_Gear(title, description, priceUA.ToString(), image,link));
            }
        }
        catch (Exception e)
        {
            if (i != 3)
            {
                goto repeat;
            }
                MessageBox.Show("Деталей з таким артикулом не знайдено", "Помилка", MessageBoxButtons.OK,MessageBoxIcon.Information);
                
                Console.WriteLine(e);

        }

        static string CleanText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            // Замінюємо кілька пробілів чи нових рядків на один пробіл
            return Regex.Replace(text, @"\s+", " ").Trim();
        }

    }
}





