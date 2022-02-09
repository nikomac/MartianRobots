using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace MartianRobots.Repositories.Helper
{
    public static class ListHelper
    {

        public static ValueComparer<List<T>> Comparer<T>()
        {
            return new ValueComparer<List<T>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.GetHashCode(),
                    c => c.ToHashSet().ToList());
        }

        public static string Serialize<T>(List<T> v)
        {
            try { return JsonSerializer.Serialize(v); } catch (Exception) { return ""; }
        }

        public static List<T> Deserialize<T>(string v)
        {
            try { return JsonSerializer.Deserialize<List<T>>(v) ?? new List<T>(); } catch (Exception) { return new List<T>(); }
        }



    }
}
