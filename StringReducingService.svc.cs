using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MonoFcgiTest.Helper;

namespace MonoFcgiTest
{
    public class StringReducingService : IStringReducingService
    {

        public string Trim(string @string) => @string.Trim();
        public string RemoveWhitespace(string @string) => @string.RemoveWhitespace();
        public string CamelCase(string @string) => @string.CamelCase();
    }
}
