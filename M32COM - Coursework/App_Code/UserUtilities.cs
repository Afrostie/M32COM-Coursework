using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.SessionState;
using System.Web;


namespace M32COM___Coursework.App_Code
{
    public class UserUtilities
    {
        //Session and server stuff
        private HttpSessionState Session;
        private HttpServerUtility Server;
        private Database userDb;
        private const string UserPath = "~/App_Data/Users.xml";

        public UserUtilities()
        {
            //Setup the Session context
            Session = HttpContext.Current.Session;
             Server = HttpContext.Current.Server;
            //Read the Users XML file
            userDb = new Database();
            userDb.ReadXml(Server.MapPath(UserPath));
        }

        /// <summary>
        /// Login a user given Username and password
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <param name="password">Unhashed Password</param>
        /// <returns>True if sucessful, false if not</returns>
        public bool LoginUser(string userName, string password)
        {
            //Check if the User Exists before continuing
            if (!UserExists(userName.Trim())) return false;

            if (password == null) return false;

            //LINQ query to find any users with same name
            var query = userDb.User.AsEnumerable().Where(a => a.Field<string>("UserName") == userName);

            //For all returned results, check for password match
            if (query.Any(user => user["Password"].ToString() == HashPassword(password + user["Salt"])))
            {
                var row = query.First();
                Session["LoggedIn"] = true;
                Session["CurrentUser"] = userName;
                Session["CurrentID"] = row["UserID"];
                Session["CurrentRole"] = row["Role"];
                return true;
            }
            return false;
        }

        /// <summary>
        /// Logout the current sessions user
        /// </summary>
        public void Logout()
        {
            Session["LoggedIn"] = false;
            Session["CurrentUser"] = null;
            Session["CurrentID"] = null;
            Session["CurrentRole"] = null;
        }

        /// <summary>
        /// Check if someone is currently logged in
        /// </summary>
        /// <returns>True is user is logged in</returns>
        public bool IsLoggedIn()
        {
             return (bool) Session["LoggedIn"];
        }

        /// <summary>
        /// Get Current UserName
        /// </summary>
        /// <returns>Current UserName</returns>
        public string GetUserName()
        {
            return (string) Session["CurrentUser"];
        }

        /// <summary>
        /// Get Current UserID
        /// </summary>
        /// <returns>Current CurrentID</returns>
        public int GetUserID()
        {
            return (int)Session["CurrentID"];
        }

        /// <summary>
        /// Get Current Role
        /// </summary>
        /// <returns>Current CurrentRole</returns>
        public string GetUserRole()
        {
            return (string)Session["CurrentRole"];
        }

        /// <summary>
        /// Hash password with SHA256
        /// </summary>
        /// <param name="password">Unhashed password with salt</param>
        /// <returns>String with Hashed Password</returns>
        private static string HashPassword(string password)
        {
            //Create a SHA256 hash
            var hashedPassword = HashAlgorithm.Create("SHA256");

            //Hash the password
            if (hashedPassword == null) return null;
            hashedPassword.ComputeHash(Encoding.UTF8.GetBytes(password));

            //Return hashed password as a string
            return Convert.ToBase64String(hashedPassword.Hash);
        }
        
        /// <summary>
        /// Check if User Exists
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <returns>True if user exists</returns>
        public bool UserExists(string userName)
        {
            var query = userDb.User.AsEnumerable().Where(a => a.Field<string>("UserName") == userName);

            return query.Any();
        }

        /// <summary>
        /// Generates some salt to add to the password before encryption
        /// </summary>
        /// <returns>String containing salt</returns>
        private static string GenerateSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            var salt = new byte[32];
            rng.GetBytes(salt);

            return Convert.ToBase64String(salt);
        }

        /// <summary>
        /// Register user with given Details
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <param name="password">Password</param>
        /// <param name="name">Full Name</param>
        /// <param name="email">Email Address</param>
        /// <param name="address">Full Address</param>
        /// <param name="role">Role: User/Admin</param>
        /// <returns>Returns true if sucessfull, false if user exists</returns>
        public bool RegisterUser(string userName, string password, string name, string email, string address, string role)
        {
            //Checks if the user already exists
            if (UserExists(userName))
                return false;

            //Generate salt and hashed password
            var salt = GenerateSalt();
            var hashedPass = HashPassword(password.Trim() + salt);
            //Add user data to the database and write the xml file
            userDb.User.AddUserRow(userName.Trim(), name.Trim(), email.Trim(), hashedPass, address.Trim(), salt, role.Trim());
            userDb.User.WriteXml(Server.MapPath(UserPath));

            return true;
        }

        public void RefreshUsers()
        {
            userDb = new Database();
            userDb.ReadXml(Server.MapPath(UserPath));
        }
    }
}