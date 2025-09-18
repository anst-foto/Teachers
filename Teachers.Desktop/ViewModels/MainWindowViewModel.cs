using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Teachers.Models;

namespace Teachers.Desktop.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly Services.Teachers _teachers;

    private Guid? _inputId;
    public Guid? InputId
    {
        get => _inputId;
        set => SetField(ref _inputId, value);
    }

    private string? _inputLastName;
    public string? InputLastName
    {
        get => _inputLastName;
        set => SetField(ref _inputLastName, value);
    }

    private string? _inputFirstName;
    public string? InputFirstName
    {
        get => _inputFirstName;
        set => SetField(ref _inputFirstName, value);
    }

    private string? _inputPatronymic;
    public string? InputPatronymic
    {
        get => _inputPatronymic;
        set => SetField(ref _inputPatronymic, value);
    }

    private DateTime? _inputBirthDate;
    public DateTime? InputBirthDate
    {
        get => _inputBirthDate;
        set => SetField(ref _inputBirthDate, value);
    }

    private string? _inputPhone;
    public string? InputPhone
    {
        get => _inputPhone;
        set => SetField(ref _inputPhone, value);
    }

    private string? _inputFaculty;
    public string? InputFaculty
    {
        get => _inputFaculty;
        set => SetField(ref _inputFaculty, value);
    }

    public ObservableCollection<string> Subjects { get; } = [];

    public ObservableCollection<Teacher> Teachers { get; } = [];
    private Teacher? _selectedTeacher;
    public Teacher? SelectedTeacher
    {
        get => _selectedTeacher;
        set
        {
            var result = SetField(ref _selectedTeacher, value);
            if (!result) return;

            InputId = value?.Id;
            InputLastName = value?.LastName;
            InputFirstName = value?.FirstName;
            InputPatronymic = value?.Patronymic;
            InputBirthDate = value?.BirthDate;
            InputPhone = value?.Phone;
            InputFaculty = value?.Faculty;

            if (value is not null)
            {
                FillObservableCollections(value?.Subjects, Subjects);
            }
        }
    }

    public ICommand CommandClear { get;}

    public MainWindowViewModel()
    {
        _teachers = new Services.Teachers();
        FillObservableCollections(_teachers.GetAll(), Teachers);

        CommandClear = new LambdaCommand(
            execute: _ => Clear(),
            canExecute: _ => CanClear());
    }

    private void FillObservableCollections<T>(IEnumerable<T> items, ObservableCollection<T> collection)
    {
        collection.Clear();
        foreach (var item in items)
        {
            collection.Add(item);
        }
    }

    private void Clear()
    {
        InputId = null;
        InputLastName = null;
        InputFirstName = null;
        InputPatronymic = null;
        InputBirthDate = null;
        InputPhone = null;
        InputFaculty = null;

        SelectedTeacher = null;
    }

    private bool CanClear() => InputId is not null
                               || !string.IsNullOrWhiteSpace(InputLastName)
                               || !string.IsNullOrWhiteSpace(InputFirstName)
                               || !string.IsNullOrWhiteSpace(InputPatronymic)
                               || !string.IsNullOrWhiteSpace(InputPhone)
                               || !string.IsNullOrWhiteSpace(InputFaculty);
}
