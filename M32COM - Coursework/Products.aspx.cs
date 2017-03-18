using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using M32COM___Coursework.App_Code;

namespace M32COM___Coursework
{
    public partial class Products : System.Web.UI.Page
    {
        private ProductUtilities productUtil;
        private UserUtilities userUtil;

        protected void Page_Load(object sender, EventArgs e)
        {
            productUtil = new ProductUtilities();
            userUtil = new UserUtilities();

            if (IsPostBack) return;

            if(!(userUtil.IsLoggedIn() && userUtil.GetUserRole() == "Admin"))
                Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            productUtil.AddProduct(TextBox1.Text, Convert.ToDouble(TextBox2.Text), TextBox3.Text,
                Convert.ToInt32(TextBox4.Text));

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
        }
    }
}