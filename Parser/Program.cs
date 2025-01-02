using System.Net.Http;
using System.Text;
using Newtonsoft.Json;


class Program
{
    static async Task InitialSearch()
    {
        Console.OutputEncoding = Encoding.Unicode;
        var client = new HttpClient();
        // Мінімальні заголовки
        client.DefaultRequestHeaders.Add("Accept", "application/json, text/plain, */*");
        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/131.0.0.0 Safari/537.36");

        repeat:

        var response = await client.GetAsync("https://exist.ua/api/v1/fulltext/search-v2/?query=6207");

        // Перевірка відповіді
        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Response JSON:");
            InitialSearch_JSON_Object.Root res = JsonConvert.DeserializeObject<InitialSearch_JSON_Object.Root>(responseBody);

            foreach (var item in res.result.products)
            {
                Console.WriteLine($"ID: {item.id}, Description: {item.description}, Price: {item.price}");
            }
        }
        else
        {
            Console.WriteLine($"Error: {response.StatusCode}");
            goto repeat;
        }
    }
}