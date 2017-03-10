using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.SessionState;
using System.Web;
using System.Web.Security;
using System.Web.Security.Cryptography;

namespace M32COM___Coursework.App_Code
{
    public class Utilities
    {
        //Session and server stuff
        private HttpSessionState Session;
        private HttpServerUtility Server;
        private Database userDb;
        private string USER_PATH = "~/App_Data/Users.xml";

        public Utilities()
        {
            //Setup the Session context
            Session = HttpContext.Current.Session;
            Server = HttpContext.Current.Server;
           //Read the Users XML file
            userDb = new Database();
            userDb.ReadXml(Server.MapPath(USER_PATH));
        }
        //Login the current user if they exist
        public bool LoginUser(string userName, string password)
        {
            //Hash the password passed in
            string hashedPass = HashPassword(password);

            //LINQ query to find any users with same name
            var query = from a in userDb.User.AsEnumerable()
                where a.Field<string>("UserName") == userName
                select a;

            //For all returned results, check username and password match
            if (query.Any(user => user["UserName"].ToString() == userName && user["Password"].ToString() == hashedPass))
            {
                Session["LoggedIn"] = true;
                Session["CurrentUser"] = userName;
                return true;
            }
            return false;
        }

        //Logout the current user
        public void Logout()
        {
            Session["LoggedIn"] = false;
            Session["CurrentUser"] = null;
        }

        //Checks whether a user is currently logged into this session
        public bool IsLoggedIn()
        {
            try{
                return (bool) Session["LoggedIn"];
            }
            catch{
                return false;
            }
            
        }
        //Helper function, returns users username
        private string GetUser()
        {
            return (string)Session["CurrentUser"];
        }

        //Hashes the given password
        private string HashPassword(string password)
        {
            if (password == null)
                return null;
            //Create a SHA256 hash
            HashAlgorithm hashedPassword =  HashAlgorithm.Create("SHA256");
            //Hash the password
            hashedPassword.ComputeHash(Encoding.UTF8.GetBytes(password));
            //Return hashed password as a string
            return Convert.ToBase64String(hashedPassword.Hash);
        }

        //Checks whether the user exists or not
        public bool UserExists(string userName)
        {
            var query = from a in userDb.User.AsEnumerable()
                        where a.Field<string>("UserName") == userName
                        select a;

            return query.Any();
        }
    }
}