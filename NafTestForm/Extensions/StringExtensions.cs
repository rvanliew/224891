using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NafTestForm.Extensions
{
    public static class StringExtensions
    {
        public static string ToStringNullSafe<T>(this T value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                return value.ToString();
            }
        }

        public static bool EqualsAnyOf<T>(this T obj, params T[] args)
        {
            return args.Contains(obj);
        }

        public static string CaseInsenstiveReplace(this string originalString, string oldValue, string newValue)
        {
            Regex regEx = new Regex(oldValue,
            RegexOptions.IgnoreCase | RegexOptions.Singleline);
            return regEx.Replace(originalString, newValue);
        }
    }
}
