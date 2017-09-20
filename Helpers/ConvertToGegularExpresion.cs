using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileSearcher.Helpers
{
    public static class ConvertToGegularExpresion
    {
        public static string Convert(string expression)
        {
            string regularExpression = expression;

            regularExpression = regularExpression.Replace(@"*", @"\.*");
            regularExpression = regularExpression.Replace(@"?", @"\.?");
            regularExpression = regularExpression.Replace(@"+", @"\.+");

            return regularExpression;
        }
    }
}
