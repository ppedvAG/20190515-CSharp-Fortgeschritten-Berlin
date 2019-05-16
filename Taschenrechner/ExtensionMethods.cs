using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    public static class ExtensionMethods
    {
        public static int Substract(this IEnumerable<int> items)
        {
            var result = items.First();
            foreach (var item in items)
            {
                result -= item;
            }
            return result;
        }
        public static string ToString2(this object obj)
        {
            return obj.ToString() + ":2";
        }
    }
}
