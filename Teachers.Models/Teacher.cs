namespace Teachers.Models;

public class Teacher : Person
{
    public required string Faculty { get; set; }
    public List<string> Subjects { get; set; } = [];
}
