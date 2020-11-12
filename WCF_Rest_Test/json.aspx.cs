using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WCF_Rest_Test
{
    public partial class json : System.Web.UI.Page
    {
        public string baseURL = "http://localhost:50700/Geri_Sayim_Rest.svc/";
        protected void Page_Load(object sender, EventArgs e)
        {
            WebClient web = new WebClient();
            web.BaseAddress = baseURL;
            web.Headers["Content-type"] = "application/json";
            web.Encoding = Encoding.UTF8;
            var veri = web.DownloadString(baseURL + "getalljson");
            //List<ApiModel> list = JsonConvert.DeserializeObject<List<ApiModel>>(veri);
            var json = new JavaScriptSerializer();
            var list = json.Deserialize<List<ApiModel>>(veri);
            
            
            gvlist.DataSource = list;

            gvlist.DataBind();
        }
    }
}