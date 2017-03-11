using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.SessionState;
using System.Web;


namespace M32COM___Coursework.App_Code
{
    public class Utilities
    {
        //Session and server stuff
        private HttpSessionState Session;
        private HttpServerUtility Server;
        private Database userDb;
        private const string UserPath = "~/App_Data/Users.xml";

        public Utilities()
        {
            //Setup the Session context
            Session = HttpContext.Current.Session;
             Server = HttpContext.Current.Server;
            //Read the Users XML file
            userDb = new Database();
            userDb.ReadXml(Server.MapPath(UserPath));
        }

        //Login the current user if they exist
        public bool LoginUser(string userName, string password)
        {
            if (password == null) return false;

            //LINQ query to find any users with same name
            var query = userDb.User.AsEnumerable().Where(a => a.Field<string>("UserName") == userName);

            //For all returned results, check for password match
            if (query.Any(user => user["Password"].ToString() == HashPassword(password + user["Salt"])))
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
             return (bool) Session["LoggedIn"];
        }

        //Helper function, returns users username
        private string GetUser()
        {
            return (string) Session["CurrentUser"];
        }

        //Hashes the given password
        private string HashPassword(string password)
        {
            //Create a SHA256 hash
            HashAlgorithm hashedPassword = HashAlgorithm.Create("SHA256");

            //Hash the password
            if (hashedPassword == null) return null;
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

        //Generates some salt to add to the password before encryption
        private static string GenerateSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[32];
            rng.GetBytes(salt);

            return Convert.ToBase64String(salt);
        }

        public bool RegisterUser(string userName, string password, string name, string email, string address)
        {
            string salt = GenerateSalt();
            string hashedPass = HashPassword(password.Trim() + salt);

            userDb.User.AddUserRow(userName.Trim(), name.Trim(), email.Trim(), hashedPass, address.Trim(), salt);
            userDb.User.WriteXml(Server.MapPath(UserPath));

            return true;
        }
    }
}