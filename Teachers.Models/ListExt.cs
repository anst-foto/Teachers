namespace Teachers.Models;

public static class ListExt
{
    public static bool TotalEqual<T>(this List<T> list, List<T> other)
    {
        return list.Count == other.Count && list.All(other.Contains);
    }
}
