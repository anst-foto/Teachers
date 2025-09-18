using System;

namespace Teachers.Models;

public abstract partial class Person
{
    public required Guid Id { get; set; }
    public required string LastName { get; set; }
    public required string FirstName { get; set; }
    public string? Patronymic { get; set; }
    public required DateTime BirthDate { get; set; }
    public required string Phone { get; set; }
}
