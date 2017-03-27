using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using M32COM___Coursework.App_Code;
using Newtonsoft.Json;

namespace M32COM___Coursework
{
    public class Quote
    {
        public double USDEUR { get; set; }
        public double USDGBP { get; set; }
    }

    public class Result
    {
        public bool success { get; set; }
        public string terms { get; set; }
        public string privacy { get; set; }
        public int timestamp { get; set; }
        public string source { get; set; }
        public Quote quotes { get; set; }
    }

    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //Address of the api and parameters
            const string address = "http://apilayer.net/api/live";
            //Andrews api access key, please no steal
            const string parameters = "?access_key=c6955da14db7d208ab9d8eb514c667db&currencies=EUR,GBP&format=1";

            //HttpClient will be in charge of getting result from api
            var client = new HttpClient();

            //Setup stuff
            client.BaseAddress = new Uri(address);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Get the result from the api
            var response = client.GetAsync(parameters).Result;

            //If the result was successfull read the result
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                //Parse the json result and store in application state
                var parsed = JsonConvert.DeserializeObject<Result>(result);

                Application["GBP"] = Convert.ToDecimal(parsed.quotes.USDGBP);
                Application["EUR"] = Convert.ToDecimal(parsed.quotes.USDEUR);
                Application["USD"] = 1.0;
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            var currentCart = new Dictionary<int ,int>();
            //Set no user to be currently logged in
            Session["LoggedIn"] = false;
            Session["CurrentUser"] = null;
            Session["CurrentID"] = null;
            Session["CurrentRole"] = "Guest";
            Session["Cart"] = currentCart;
            Session["DropDownID"] = 4;
            Session["CurrentRate"] = 1.0M;
            Session["CurrentFormat"] = "$";
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Session.Abandon();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}