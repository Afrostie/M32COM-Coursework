using System;
using System.Web.UI;
using M32COM___Coursework.App_Code;

namespace M32COM___Coursework
{
    public partial class Login : Page
    {
        //Object instances
        private UserUtilities userUtil;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Create the instance of UserUtilities class
            userUtil = new UserUtilities();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Try and login the User
            if (userUtil.LoginUser(UserNameTB.Text, PasswordTB.Text))
                // If User and Password are correct, move to another page
                Response.Redirect("Orders.aspx");
            //Otherwise tell the user to register
            else
                Response.Write("Incorrect Details");   
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            if (userUtil.UserExists(UserRegister.Text))
            {
                Response.Write("User Already Exists");
            }
            else
            {
                userUtil.RegisterUser(UserRegister.Text, PasswordRegister.Text, NameRegister.Text, EmailRegister.Text, AddressRegister.Text, "User");

                userUtil.RefreshUsers();

                RegisterPanel.Visible = false;
                LoginPanel.Visible = true;
            } 

        }

        protected void ShowLogin_Click(object sender, EventArgs e)
        {
            RegisterPanel.Visible = false;
            LoginPanel.Visible = true;
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterPanel.Visible = true;
            LoginPanel.Visible = false;
        }
    }
}