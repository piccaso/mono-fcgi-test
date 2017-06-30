using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MonoFcgiTest
{
    [ServiceContract]
    public interface IStringReducingService
    {
        [OperationContract]
        string Trim(string @string);

        [OperationContract]
        string RemoveWhitespace(string @string);

        [OperationContract]
        string CamelCase(string @string);
    }
}