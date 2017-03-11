using System;
using System.Web.UI;
using M32COM___Coursework.App_Code;

namespace M32COM___Coursework
{
    public partial class Login : Page
    {
        //Location of the Users document
        private const string UserPath = "App_Data/Users.xml";
        private Database userDb;
        //Object instances
        private Utilities util;

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

        protected void Register_Click(object sender, EventArgs e)
        {
            util.RegisterUser(TextBox1.Text, TextBox2.Text, TextBox4.Text, TextBox3.Text, TextBox5.Text);
        }
    }
}