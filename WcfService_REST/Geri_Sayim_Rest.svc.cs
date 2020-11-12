using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService_REST
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Geri_Sayim_Rest
    {
        geri_sayim_apiEntities db = new geri_sayim_apiEntities();
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public string DoWork()
        {
            // Add your operation implementation here
            return "Hello World";
        }

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "getalljson")]
        public List<Geri_Sayimlar> GetAllJson()
        {
            var liste = db.Geri_Sayimlar.ToList();
            return liste;
        }

        [OperationContract]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, UriTemplate = "getallxml")]
        public List<Geri_Sayimlar> GetAllXML()
        {
            var liste = db.Geri_Sayimlar.ToList();
            return liste;
        }
    }
}
