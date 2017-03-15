﻿using System;
using System.Collections.Generic;
using M32COM___Coursework.App_Code;

namespace M32COM___Coursework
{
    public partial class Default : System.Web.UI.Page
    {
        private UserUtilities userUtil;
        private CartUtilities cartUtil;
        protected void Page_Load(object sender, EventArgs e)
        {
            cartUtil = new CartUtilities();
            userUtil = new UserUtilities();
            //If the user is logged in, let them into page
            if (userUtil.IsLoggedIn())
                Response.Write("Successfully Logged In");
            //Otherwise redirect back to login page
            else
                Response.Redirect("Login.aspx");

            var test = (Dictionary<int, int>) Session["Cart"];
            var hello = "";

            if (IsPostBack) return;
            foreach (var tmp in test)
            {
                hello = hello + tmp.Key + " ";
            }
            CartLabel.Text = hello;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //When Logout button is clicked, logout and go back to login page
            userUtil.Logout();
            Response.Redirect("Login.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            cartUtil.AddNewItemToCart(5, 1);
            cartUtil.AddNewItemToCart(5, 1);
            cartUtil.AddNewItemToCart(2, 1);
        }
    }
}