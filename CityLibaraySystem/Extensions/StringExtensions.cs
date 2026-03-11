using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CityLibaraySystem.Extensions
{
    public static class StringExtensions
    {
        public  static  string NormalizedId(this string Id)
        {
            return Id?.Trim().ToUpperInvariant() ?? string.Empty;
        }
    }
}
