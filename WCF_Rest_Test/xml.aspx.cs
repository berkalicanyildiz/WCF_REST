using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WCF_Rest_Test
{
    public partial class xml2 : System.Web.UI.Page
    {
        public string baseURL = "http://localhost:50700/Geri_Sayim_Rest.svc/";
          protected void Page_Load(object sender, EventArgs e)
        {
            WebClient web = new WebClient();
            web.BaseAddress = baseURL;
            web.Headers["Content-type"] = "application/xml";
            web.Encoding = Encoding.UTF8;

            var xml = web.DownloadString(baseURL+"getallxml");

            DataSet ds = new DataSet();
            XmlTextReader reader = new XmlTextReader(new StringReader(xml));
            ds.ReadXml(reader);

            gvlist.DataSource = ds;
            gvlist.DataBind();
        }
    }
}