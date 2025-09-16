using System.IO;
using System.Text.Json;
using Teachers.Desktop.Models;

namespace Teachers.Desktop.DataAccesses;

public static class JsonService
{
    public static void Save(IEnumerable<Teacher> teachers, string path = "teachers.json")
    {
        var json = JsonSerializer.Serialize(teachers);
        File.WriteAllText(path, json);
    }

    public static IEnumerable<Teacher>? Load(string path = "teachers.json")
    {
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<IEnumerable<Teacher>>(json);
    }
}
