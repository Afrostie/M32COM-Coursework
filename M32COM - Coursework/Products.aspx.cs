using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using M32COM___Coursework.App_Code;
using System.Xml.Linq;
using System.Xml;

namespace M32COM___Coursework
{
    public partial class Products : System.Web.UI.Page
    {
        private ProductUtilities productUtil;
        private UserUtilities userUtil;
        private CartUtilities cartUtilities;

        protected void Page_Load(object sender, EventArgs e)
        {
            productUtil = new ProductUtilities();
            userUtil = new UserUtilities();
            cartUtilities = new CartUtilities();

            if (IsPostBack) return;

            if (userUtil.GetUserRole() == "Admin")
                pnlAdmin.Visible = true;

            //Displays all cakes in a certain category
            //rptSingleCake.DataSource = productUtil.GetTableByCategory("Celebration-Cakes");
            //Displays all cakes
            rptSingleCake.DataSource = productUtil.GetTable();
            rptSingleCake.DataBind();
        }

        //Add a new product to the products xml
        protected void AddCake_Click(object sender, EventArgs e)
        {
            //Gets filename and path to save the image to
            var fileName = ImageUpload.FileName;
            var category = CategoryDropDown.SelectedItem.Value;

            var path = "~/Images/" + category + "/";

            ImageUpload.SaveAs(Server.MapPath(path) + fileName);

            productUtil.AddProduct(txtBoxCakeName.Text, Convert.ToDouble(txtBoxCakePrice.Text), txtBoxCakeDescription.Text,
                Convert.ToInt32(txtBoxCakeStock.Text), path + fileName, category);

            txtBoxCakeName.Text = "";
            txtBoxCakePrice.Text = "";
            txtBoxCakeDescription.Text = "";
            txtBoxCakeStock.Text = "";
        }

        //Adds the correct item to cart when button is clicked
        protected void rptSingleCake_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                var tmp = e.CommandArgument.ToString();
                cartUtilities.AddNewItemToCart(Convert.ToInt32(tmp), 1);
                Response.Redirect("Products.aspx");
            }
        }
    }
}