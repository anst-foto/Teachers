using System.Collections.Generic;
using System.Linq;

namespace Teachers.Models;

public static class ListExt
{
    public static bool TotalEquals<T>(this List<T> list, List<T> other)
    {
        return list.Count == other.Count
               && list.All(other.Contains);
    }
}
