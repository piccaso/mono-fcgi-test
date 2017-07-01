using System.ServiceModel;

namespace MonoFcgiTest.Contracts
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