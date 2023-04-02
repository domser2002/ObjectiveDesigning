using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    static class Extensions
    {
        public static void AddOrIgnore(this Dictionary<int, string> dictionary, int key, string value)
        {
            if (!dictionary.ContainsKey(key))
                dictionary.Add(key, value);
        }
        public static bool Find<T>(this IMyCollection<T> collection)
        {
            return false;
        }

    }
}
