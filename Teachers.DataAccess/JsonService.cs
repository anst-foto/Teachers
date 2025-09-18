using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using Teachers.Models;

namespace Teachers.DataAccess;

public static class JsonService
{
    public static void Save(IEnumerable<Teacher> teachers, string path = "teachers.json")
    {
        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        };
        options.Converters.Add(new CustomDateTimeConverter("yyyy-MM-dd"));
        var json = JsonSerializer.Serialize(teachers, options);
        File.WriteAllText(path, json);
    }

    public static IEnumerable<Teacher>? Load(string path = "teachers.json")
    {
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<IEnumerable<Teacher>>(json);
    }
}
