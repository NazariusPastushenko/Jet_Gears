using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Jet_Gears.DataBases;

public class GeminiClient
{
    private readonly string _apiKey;
    private readonly HttpClient _httpClient;

    public GeminiClient(string apiKey)
    {
        _apiKey = apiKey;
        _httpClient = new HttpClient();
    }

    public async Task<string> GetCompletion(string prompt)
    {
        var request = new
        {
            contents = new[]
            {
                new { parts = new[] { new { text = prompt } } }
            }
        };

        var json = JsonSerializer.Serialize(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Додаємо API ключ до URL-адреси
        string apiUrl = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={_apiKey}";

        var response = await _httpClient.PostAsync(apiUrl, content);
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();
        var responseData = JsonSerializer.Deserialize<JsonResponse>(responseJson);

        return responseData?.candidates?[0]?.content?.parts?[0]?.text?.Trim() ?? "Вибачте, не можу відповісти на це запитання.";
    }

    private class JsonResponse
    {
        public Candidate[]? candidates { get; set; }
    }

    private class Candidate
    {
        public Content? content { get; set; }
    }

    private class Content
    {
        public Part[]? parts { get; set; }
    }

    private class Part
    {
        public string? text { get; set; }
    }
}