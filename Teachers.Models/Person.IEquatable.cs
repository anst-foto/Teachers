using System;

namespace Teachers.Models;

public abstract partial class Person : IEquatable<Person>
{
    public bool Equals(Person? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id
               && LastName == other.LastName
               && FirstName == other.FirstName
               && Patronymic == other.Patronymic
               && BirthDate.Equals(other.BirthDate)
               && Phone == other.Phone;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Person)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, LastName, FirstName, Patronymic, BirthDate, Phone);
    }

    public static bool operator ==(Person? left, Person? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Person? left, Person? right)
    {
        return !Equals(left, right);
    }
}
