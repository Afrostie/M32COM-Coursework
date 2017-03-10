using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
namespace M32COM___Coursework.App_Code
{
    public class Utilities
    {
        private HttpSessionState Session;
        private HttpServerUtility Server;
        private Database UserDB;
        private string USER_PATH = "~/App_Data/Users.xml";

        public Utilities()
        {
            Session = HttpContext.Current.Session;
            Server = HttpContext.Current.Server;
           
            UserDB = new Database();
            UserDB.ReadXml(Server.MapPath(USER_PATH));
        }
        //Login
        public bool LoginUser(string userName, string password)
        {
            var userFound = false;

            var query = from a in UserDB.User.AsEnumerable()
                where a.Field<string>("UserName") == userName
                select a;

            foreach (var user in query)
            {
                if (user["UserName"].ToString() == userName && user["Password"].ToString() == password)
                {
                    Session["LoggedIn"] = true;
                    Session["CurrentUser"] = userName;
                    userFound = true;
                }
            }
            return userFound;
        }
        //Logout
        public void Logout()
        {
            Session["LoggedIn"] = false;
            Session["CurrentUser"] = null;
        }

        //isLoggedIn
        public bool IsLoggedIn()
        {
            try{
                return (bool) Session["LoggedIn"];
            }
            catch{
                return false;
            }
            
        }
        //User name
        private string GetUser()
        {
            return "temp";
        }
    }
}