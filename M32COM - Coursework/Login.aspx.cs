using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using M32COM___Coursework.App_Code;

namespace M32COM___Coursework
{
    public partial class Login : System.Web.UI.Page
    {
        //Object instances
        private Utilities util;
        private Database userDb;
        //Location of the Users document
        private const string UserPath = "App_Data/Users.xml";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Create hte instance of Utilities class
            util = new Utilities();
            //Load and read the User XML data
            userDb = new Database();
            userDb.ReadXml(Server.MapPath(UserPath));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //Try and login the User
            if (util.LoginUser(UserNameTB.Text, PasswordTB.Text))
               // If User and Password are correct, move to another page
                Response.Redirect("Default.aspx");
            //Otherwise tell the user to register
            else
                Response.Write("User Does Not Exist, Please Register");
        }
    }
}