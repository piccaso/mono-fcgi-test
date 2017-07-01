using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MonoFcgiTest.Contracts;

namespace MonoFcgiTest.Controllers
{
    public class ComplexValuesController : ApiController
    {
        [HttpGet]
        public SomeComplexType GetExample(int recursion) => SomeComplexType.Factory(recursion);

        [HttpPost]
        public SomeComplexType Passthrou([FromBody] SomeComplexType @in) => @in;
    }
}