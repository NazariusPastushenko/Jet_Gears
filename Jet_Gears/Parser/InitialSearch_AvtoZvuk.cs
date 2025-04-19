using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Jet_Gears.Objects;

namespace Jet_Gears.Parser;

public class InitialSearch_AvtoZvuk
{
        public static async void Initial_Search_Zvuk(string article,string type)
    {
        
        string url = "https://avtozvuk.ua/ua/search?text=" + article;

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
            var productNodes = document.DocumentNode.SelectNodes("//div[contains(@class, 'products-layout__product-item')]");


            // Знаходимо всі елементи з класом product-card

            foreach (var productCard in productNodes)
            {

                // Назва товару
                var titleNode = productCard.SelectSingleNode(".//div[@class='product-view-title']/a");
                var title = CleanText(titleNode?.InnerText);

                // Ціна товару
                var priceNode = productCard.SelectSingleNode(".//div[@class='product-view-prices__base-price-number']");
                var price = CleanText(priceNode?.InnerText);

                // Посилання на товар
                var linkNode = productCard.SelectSingleNode(".//div[@class='product-view-header__wrap-img']/a");
                var href = linkNode?.GetAttributeValue("href", "No link");
                href = "https://avtozvuk.ua" + href;
                
                // Зображення товару (за допомогою XPath для атрибуту src)
                var imageNode = productCard.SelectSingleNode(".//div[@class='product-view-header__wrap-img']/a/img");
                var imageUrl = imageNode?.GetAttributeValue("data-src", imageNode?.GetAttributeValue("src", "none"));


                Console.WriteLine($"Назва: {title}");
                Console.WriteLine($"Ціна: {price}");
                char symbol = '\u20B4';
                Console.WriteLine($"Зображення: {imageUrl}");
                Console.WriteLine($"Посилання: {href}");
                Console.WriteLine(new string('=', 30));


                Categories.SearchGears.Add(new Search_Gear(title, "", price+symbol, imageUrl,href));
            }
            Categories.SearchGears = Categories.SearchGears
                .OrderBy(g =>
                {
                    string cleaned = new string(g.price
                        .Where(c => char.IsDigit(c) || c == '.' || c == ',')
                        .ToArray());

                    // замінити кому на крапку, якщо це потрібно
                    cleaned = cleaned.Replace(',', '.');

                    decimal.TryParse(cleaned, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result);
                    return result;
                })
                .ToList();
        }
        catch (Exception e)
        {
            if (i != 3)
            {
                goto repeat;
            } 
            Console.WriteLine(e);
            Console.WriteLine("111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111");

        }

        static string GetPrice(HtmlNode priceNode)
        {
            if (priceNode == null) return "Немає ціни";

            // Витягуємо всю ціну разом із символами та пробілами
            var priceText = HtmlEntity.DeEntitize(priceNode.InnerText).Trim();
            return Regex.Replace(priceText, @"\s+", " ");
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