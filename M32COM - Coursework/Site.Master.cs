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
        private ProductUtilities productUtil;
        private UserUtilities userUtil;
        private CartUtilities cartUtil;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Create the instance of ProductUtilities class
            productUtil = new ProductUtilities();
            //Create the instance of CartUtilities class
            cartUtil = new CartUtilities();
            //Create the instance of UserUtilities class
            userUtil = new UserUtilities();

            lblCart.Text = Convert.ToString(cartUtil.GetItemCount());
            if (cartUtil.GetItemCount() == 1)
            {
                lblCart.Text = "1 Item";
            }
            else if (cartUtil.GetItemCount() > 1)
            {
                lblCart.Text = cartUtil.GetItemCount() + " Items";
            }

            if (userUtil.IsLoggedIn())
                LogIn();
        }

        protected void LogIn_Click(object sender, EventArgs e)
        {
            //Try and login the User
            if (userUtil.LoginUser(UserNameTB.Text, PasswordTB.Text))
            {
                LogIn();
                    
                var page = this.Page.Request.FilePath;

                Response.Write("<script>alert('Please Login');</script>");

                Response.Redirect(page);
                
            }
            
            //Otherwise tell the user to register
            else
                Response.Write("<script>alert('Login Unsuccessful');</script>");
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

        protected void ddHeaderCurrencies_SelectedIndexChanged(object sender, EventArgs e)
        {
            productUtil.SetCurrency(ddHeaderCurrencies.SelectedItem.Text);
            Response.Redirect(this.Page.Request.FilePath);
        }
    }
}