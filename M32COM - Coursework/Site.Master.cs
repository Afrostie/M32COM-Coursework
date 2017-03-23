﻿using System;
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

            //If the user is logged in, let them into page
            if (userUtil.IsLoggedIn())
                Response.Write("Successfully Logged In as " + userUtil.GetUserName() + " with ID " + userUtil.GetUserID() + " with role " +
            userUtil.GetUserRole());

            CartLabel2.Text = Convert.ToString(cartUtil.GetItemCount());
        }

        protected void LogIn_Click(object sender, EventArgs e)
        {
            //Try and login the User
            if (userUtil.LoginUser(UserNameTB.Text, PasswordTB.Text))
            {
                // If User and Password are correct, move to another page
                lblUserName.Text = userUtil.GetUserName();
                pnlLogIn.Visible = false;
            }

            //Otherwise tell the user to register
            else
                Response.Write("User Does Not Exist, Please Register");
        }



        protected void LogOut_Click(object sender, EventArgs e)
        {
            //When Logout button is clicked, logout and go back to login page
            userUtil.Logout();
            Response.Redirect("Login.aspx");
        }
    }
}