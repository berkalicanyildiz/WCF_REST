using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WCF_Rest_Test
{
    public partial class auth_test : System.Web.UI.Page
    {
        public string baseURL = "http://localhost:50700/Rest_Auth.svc/";

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(baseURL+"DoWork");
            //Add a header to the request that contains our credentials
            //DO NOT HARDCODE IN PRODUCTION!! Pull credentials real-time from database or other store.
            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("berk" + ":" + "123"));
            req.Headers.Add("Authorization", "Basic " + svcCredentials);
            //Just some example code to parse the JSON response using the JavaScriptSerializer
            using (WebResponse svcResponse = (HttpWebResponse)req.GetResponse())
            {
                using (StreamReader sr = new StreamReader(svcResponse.GetResponseStream()))
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string jsonTxt = sr.ReadToEnd();
                    lbltest.Text = jsonTxt;
                }
            }

            

        }
    }
}