using System;
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
        try
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
        catch (Exception e)
        {
            throw new SaveToJsonException(path, e);
        }
    }

    public static IEnumerable<Teacher> Load(string path = "teachers.json")
    {
        try
        {
            var json = File.ReadAllText(path);
            var teachers =  JsonSerializer.Deserialize<IEnumerable<Teacher>>(json);

            if (teachers is null) throw new LoadFromJsonException(path);

            return teachers;
        }
        catch (Exception e)
        {
            throw new LoadFromJsonException(path, e);
        }
    }
}
