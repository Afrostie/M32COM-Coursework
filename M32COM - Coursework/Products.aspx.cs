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

            if (userUtil.GetUserRole() == "Admin")
                pnlAdmin.Visible = true;
        }

        protected void AddCake_Click(object sender, EventArgs e)
        {
            productUtil.AddProduct(txtBoxCakeName.Text, Convert.ToDouble(txtBoxCakePrice.Text), txtBoxCakeDescription.Text,
                Convert.ToInt32(txtBoxCakeStock.Text));

            txtBoxCakeName.Text = "";
            txtBoxCakePrice.Text = "";
            txtBoxCakeDescription.Text = "";
            txtBoxCakeStock.Text = "";
        }
    }
}