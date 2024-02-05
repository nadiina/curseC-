
using System.Text.Json;

namespace ConsoleApp1.DataAccess;

public class StringJsonRepository : StringRepository
{
    protected override string StringeToText(List<string> strings)
    {
        return JsonSerializer.Serialize(strings, new JsonSerializerOptions { WriteIndented = true });
    }

    protected override List<string> TextToStrings(string fileContents)
    {
        return JsonSerializer.Deserialize<List<string>>(fileContents);
    }
}
