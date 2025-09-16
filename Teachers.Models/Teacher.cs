namespace Teachers.Models;

public partial class Teacher : Person
{
    public required string Faculty { get; set; }
    public List<string> Subjects { get; set; } = [];
}
