using System;

namespace Teachers.Models;

public partial class Teacher : IEquatable<Teacher>
{
    public bool Equals(Teacher? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return base.Equals(other)
               && Faculty == other.Faculty
               && Subjects.TotalEquals(other.Subjects);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Teacher)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), Faculty, Subjects);
    }

    public static bool operator ==(Teacher? left, Teacher? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Teacher? left, Teacher? right)
    {
        return !Equals(left, right);
    }
}
