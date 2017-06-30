using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MonoFcgiTest.Helper;

namespace MonoFcgiTest.Controllers
{
    public class StringReduceController : ApiController, IStringReducingService
    {
        [HttpGet]
        public string Trim(string @string) => @string.Trim();

        [HttpGet]
        public string RemoveWhitespace(string @string) => @string.RemoveWhitespace();

        [HttpGet]
        public string CamelCase(string @string) => @string.CamelCase();
    }
}
