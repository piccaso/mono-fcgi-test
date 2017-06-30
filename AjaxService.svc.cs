using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace MonoFcgiTest
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AjaxService
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract, WebGet]
        public DoWorkResponse DoWork(int i, long l, string s) => new DoWorkResponse {I=i,L=l,S=s};

        // Add more operations here and mark them with [OperationContract]
    }

    public class DoWorkResponse
    {
        public int I { get; set; }
        public long L { get; set; }
        public string S { get; set; }
    }
}
