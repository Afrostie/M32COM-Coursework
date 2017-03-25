using System;
using System.Collections.Generic;
using M32COM___Coursework.App_Code;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace M32COM___Coursework
{
    public partial class Site : System.Web.UI.MasterPage
    {
        //Object instances
        private UserUtilities userUtil;
        private CartUtilities cartUtil;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Create the instance of CartUtilities class
            cartUtil = new CartUtilities();
            //Create the instance of UserUtilities class
            userUtil = new UserUtilities();

            if (IsPostBack) return;

            lblCart.Text = Convert.ToString(cartUtil.GetItemCount());

            if (userUtil.IsLoggedIn())
                LogIn();
        }

        protected void LogIn_Click(object sender, EventArgs e)
        {
            //Try and login the User
            if (userUtil.LoginUser(UserNameTB.Text, PasswordTB.Text))
                LogIn();

            //Otherwise tell the user to register
            else
                Response.Write("User Does Not Exist, Please Register");
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            //When Logout button is clicked, logout and go back to login page
            userUtil.Logout();
            Response.Redirect("Default.aspx");
        }

        //Handles hiding/showing appropriate panels if use is logged in
        private void LogIn()
        {
            lblUserName.Text = userUtil.GetUserName();
            pnlLogIn.Visible = false;

            lblUserName.Visible = true;
            btnLogOut.Visible = true;

            if (userUtil.GetUserRole() == "Admin")
                pnlAdmin.Visible = true;
        }

        protected void CustomValidatorPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string data = args.Value;
            args.IsValid = false; //start by setting false
            if (data.Length < 6 || data.Length > 12) return;
            bool uc = false;
            foreach (char c in data)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    uc = true; break;
                }
            }
            if (!uc) return;
            bool lc = false;
            foreach (char c in data)
            {
                if (c >= 'a' && c <= 'z')
                {
                    lc = true; break;
                }
            }
            if (!lc) return;
            bool num = false;
            foreach (char c in data)
            {
                if (c >= '0' && c <= '9')
                {
                    num = true; break;
                }
            }
            if (!num) return;
            args.IsValid = true;
        }
    }
}