using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class OpenAIClient
{
    private readonly string _apiKey;

    public OpenAIClient(string apiKey)
    {
        _apiKey = apiKey;
    }

    public async Task<string> SendRequest(string prompt)
    {
        using HttpClient client = new();
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

        var requestBody = new
        {
            model = "gpt-3.5-turbo",
            messages = new[]
            {
                new { role = "user", content = prompt }
            }
        };

        var content = new StringContent(
            JsonSerializer.Serialize(requestBody),
            Encoding.UTF8,
            "application/json"
        );

        var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
        var jsonResponse = await response.Content.ReadAsStringAsync();

        using JsonDocument json = JsonDocument.Parse(jsonResponse);
        return json.RootElement
                   .GetProperty("choices")[0]
                   .GetProperty("message")
                   .GetProperty("content")
                   .GetString();
    }
}
