using System;using System.Drawing.Drawing2D;
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
public class InitialSearch
{ 
    public static async void Initial_Search(string article)
    {
        var i = 0;
        
        Console.OutputEncoding = Encoding.Unicode;
        Repeat:
        Categories.Search_Gears.Clear();
        i++;
        var web = new HtmlWeb();
        try
        {
            var document = web.Load("https://www.onlinecarparts.co.uk/spares-search.html?keyword=" + article);
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
                var priceNode = productCard.SelectSingleNode(".//div[@class='product-card__price']//div[@class='product-card__new-price']");
                var price = priceNode?.InnerText.Trim();
                    
            
                var imageNode = productCard.SelectSingleNode(".//div[@class='product-card__image']//img[@class='lazyload']");
                var image = imageNode?.Attributes["src"]?.Value.Trim();

            
                    
                // Очистка від зайвих символів нового рядка
                description = CleanText(description);
                price = CleanText(price);
                price = price.Remove(0,8);
              

                // Виводимо зібрані дані
                    
                Console.WriteLine($"Title: {title}");
                Console.WriteLine($"Description: {description}");
                Console.WriteLine($"Price: {price}");
                Console.WriteLine($"ImageURL: {image}");
                Console.WriteLine(new string('-', 30));
                
                var translator = new GoogleTranslator();
                
                var title_ua = translator.TranslateAsync(title, "uk");
                var description_ua = translator.TranslateAsync(description, "uk");
                var price_ua = translator.TranslateAsync(price, "uk");
            
                Categories.Search_Gears.Add(new Search_Gear(title_ua.Result.Translation,description,price,image));
            }
        }
        catch (Exception e)
        {
            if (i < 3){goto Repeat;}
            MessageBox.Show("Деталей з таким артикулом не знайдено", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
        
       
    }
    
    static string CleanText(string text)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;

        // Замінюємо кілька пробілів чи нових рядків на один пробіл
        return Regex.Replace(text, @"\s+", " ").Trim();
    }

}





