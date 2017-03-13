using System;
using M32COM___Coursework.App_Code;

namespace M32COM___Coursework
{
    public partial class Default : System.Web.UI.Page
    {
        private Utilities util;

        protected void Page_Load(object sender, EventArgs e)
        {
            util = new Utilities();
            //If the user is logged in, let them into page
            if (util.IsLoggedIn())
                Response.Write("Successfully Logged In");
            //Otherwise redirect back to login page
            else
                Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //When Logout button is clicked, logout and go back to login page
            util.Logout();
            Response.Redirect("Login.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}