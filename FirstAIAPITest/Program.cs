using System.Formats.Asn1;
using System.Net.WebSockets;
using System.Text.Json;

namespace FirstAIAPITest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var apiKey = "YOUR_API_KEY";

            using var _http = new HttpClient();
            
            _http.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            Console.WriteLine("Hi! I am BEX 0.6.0");
            Console.WriteLine("What can I help you with?");

            var prompt = Console.ReadLine();
            var requestBody = new
            {
                model = "llama-3.1-8b-instant",
                messages = new[]
                {
                    new { role = "system", content = "You are BEX, a precise AI assistant.\r\nIf you do not know something, say you don't know instead of guessing.\r\nDo not hallucinate facts like dates or real-world data." },
                    new { role = "user", content = prompt }
                }
            };
            
            var json = JsonSerializer.Serialize(requestBody);
           
            var result = await _http.PostAsync("https://api.groq.com/openai/v1/chat/completions", new StringContent(json, System.Text.Encoding.UTF8, "application/json"));


            var answer = await result.Content.ReadAsStringAsync();


            var jsonDoc = JsonDocument.Parse(answer);

            var text = jsonDoc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            Console.WriteLine("\n\n---BEX 0.6.0 (using Groq AI API) ---");
            Console.WriteLine("----------------------------------");
            Console.WriteLine(text);
            Console.WriteLine("----------------------------------");
        }
    }
}
