using System.Net.Http.Json;
using System.Text.Json;

namespace poc.JsonStreamConsumer;

class Program
{
    static async Task Main(string[] args)
    {
        var client = new HttpClient { BaseAddress = new Uri("http://localhost:5249") }; // Adjust the port accordingly

        // Make the request and get the response stream
        using var response = await client.GetAsync("stream", HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();

        // Deserialize the response stream asynchronously
        var stream = await response.Content.ReadAsStreamAsync();
        var dataItems = JsonSerializer.DeserializeAsyncEnumerable<DataItem>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Process each item as it is received
        await foreach (var item in dataItems)
        {
            Console.WriteLine($"Received: {item.Id} - {item.Name}");
        }
    }

    private class DataItem
    {  
        public int Id { get; set; }
        public string Name { get; set; }
    }
}