using System;
using System.Collections.Generic;
using System.Linq;
using Teachers.DataAccess;
using Teachers.Models;

namespace Teachers.Services;

public class Teachers
{
    private readonly Dictionary<Guid, Teacher> _teachers = [];

    public Teachers()
    {
        Init();
    }

    public IEnumerable<Teacher> GetAll() => _teachers.Values;
    public IEnumerable<Teacher>? GetByName(string name) =>
        _teachers.Values.Where(t => t.LastName == name
                                    || t.FirstName == name
                                    || t.Patronymic == name);
    public Teacher? GetById(Guid id) =>
        _teachers.GetValueOrDefault(id);

    public bool Delete(Guid id) =>
        _teachers.Remove(id);

    public bool Add(Teacher teacher) =>
        _teachers.TryAdd(teacher.Id, teacher);

    public bool Update(Teacher teacher)
    {
        var _teacher = GetById(teacher.Id);
        if (_teacher is null) return false;

        _teachers[teacher.Id] = teacher;
        return true;
    }

    public void Save() => JsonService.Save(_teachers.Values);
    public void Load() => Init();

    private void Init()
    {
        _teachers.Clear();

        var teachers = JsonService.Load();
        foreach (var teacher in teachers)
        {
            _teachers.Add(teacher.Id, teacher);
        }
    }
}
