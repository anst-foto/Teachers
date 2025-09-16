using Teachers.DataAccess;
using Teachers.Models;

var teacher = new Teacher()
{
    LastName = "Старинин",
    FirstName = "Андрей",
    Patronymic = "Николаевич",
    BirthDate = new DateTime(1980, 1, 1),
    Phone = "+79042144491",
    Faculty = "SoftDev"
};
teacher.Subjects.Add("C#");
teacher.Subjects.Add("SQL");

var teachers = new List<Teacher> { teacher };

JsonService.Save(teachers);

var loadedTeachers = JsonService.Load();
foreach (var t in loadedTeachers)
{
    Console.WriteLine(t == teacher);
    Console.WriteLine(t);
}
