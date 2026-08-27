using System.Collections;
using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json;
using CsvHelper;

namespace MtgCsWriter;

internal class Program
{
    public static async Task Main()
    {
        HttpClient client = new()
        {
            BaseAddress = new Uri ("https://api.scryfall.com"),
            DefaultRequestHeaders = { 
                { "Accept", "application/json" },
                { "User-Agent", "C# HttpClient" }
            }
        };
        ListObject? response = await client.GetFromJsonAsync<ListObject>("sets", new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        });
        
        if (response is null)
        {
            Console.WriteLine("Scryfall did not respond as expected, please try again later.");
            return;
        }

        List<SetObject> handledSets = response.Data
            .Where(set => set.Code.Length == 3)
            .OrderBy(set => set.ReleasedAt)
            .ToList();

        string storeDirectory = Directory.GetCurrentDirectory();
        string csvPath = Path.Combine(storeDirectory, $"MTG-{DateTime.Now:yyyy-MM-dd}.csv");
        
        await using var writer = new StreamWriter(csvPath);
        await using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        await csv.WriteRecordsAsync((IEnumerable)handledSets);
    }
}

public record SetObject(string Name, string Code, string ScryfallUri, DateOnly ReleasedAt, string IconSvgUri)
{
    public override string ToString()
    {
        return $"{{\"Name\":\"{Name}\",\"Code\":{Code}\",\"ScryfallUri\":\"{ScryfallUri}\",\"ReleasedAt\":\"{ReleasedAt}\",\"IconSvgUri\":\"{IconSvgUri}\"}}";
    }
}

public record ListObject(string Object, bool HasMore, SetObject[] Data);