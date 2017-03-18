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
                Response.Redirect("Default.aspx");
            //Otherwise tell the user to register
            else
                Response.Write("User Does Not Exist, Please Register");
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            if(userUtil.UserExists(TextBox1.Text))
                Response.Write("User Exists");
            userUtil.RegisterUser(TextBox1.Text, TextBox2.Text, TextBox4.Text, TextBox3.Text, TextBox5.Text, DropDownList1.SelectedValue);
        }
    }
}