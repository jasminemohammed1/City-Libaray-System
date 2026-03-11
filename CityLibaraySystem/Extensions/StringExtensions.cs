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
        public static string NormalizedId(this string Id)
        {
            return Id?.Trim().ToUpperInvariant() ?? string.Empty;
        }

        public static bool IsValidEmail(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;

            bool HasDot = false;
            bool HasAt = false;
            for (int i = 0; i < value.Length; i++)
            {
                if (value[i] == '.') { HasDot = true; }
                if (value[i] == '@')
                {
                    HasAt = true;
                }
            }
            return HasDot & HasAt;
        }
        public static bool ContainsDigit(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsDigit(value[i]))
                    return true;
            }
            return false;
        }
    }

}
    