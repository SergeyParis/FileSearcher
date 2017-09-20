using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearcher.Helpers
{
    internal static class ExtensibleMethods
    {
        private static readonly object Locked = new object();
        
        public static void AddRangeAsync<T>(this List<T> list, IEnumerable<T> collection)
        {
            lock (Locked)
            {
                list.AddRange(collection);
            }
        }
    }
}
