using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace MonoFcgiTest.Helper
{
    public static class StringReducer
    {
        public static string RemoveWhitespace(this string s) => Regex.Replace(s, @"\s+", "");

        public static string CamelCase(this string @string)
        {
            return Regex.Split(@string, @"\s")
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToCamelCaseCollection()
                .ConcatCollection();
        }

        private static IEnumerable<string> ToCamelCaseCollection(this IEnumerable<string> @string)
            => @string.Select(FirstToUppercase);

        private static string FirstToUppercase(this string @string)
        {
            var sb = new StringBuilder();
            if (@string.Length > 0)
            {
                sb.Append(char.ToUpper(@string[0]));
            }
            if (@string.Length > 1)
            {
                sb.Append(@string.Substring(1));
            }
            return sb.ToString();
        }

        private static string ConcatCollection(this IEnumerable<string> strings) => string.Join("", strings);

       
    }


}