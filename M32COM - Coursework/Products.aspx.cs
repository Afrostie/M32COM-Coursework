using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

        //TODO: Add Quantity Dropdown to Repeater on Products

        protected void Page_Load(object sender, EventArgs e)
        {
            productUtil = new ProductUtilities();
            userUtil = new UserUtilities();
            cartUtilities = new CartUtilities();

            if (IsPostBack) return;

            if (userUtil.GetUserRole() == "Admin")
                pnlAdmin.Visible = true;

            //Displays all cakes in a ceTrtain category
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

            var tmp = path + fileName;

            decimal tmpDecimal = Convert.ToDecimal(txtBoxCakePrice.Text);

            if ((tmpDecimal % 1) == 0)
                txtBoxCakePrice.Text += ".00";

            productUtil.AddProduct(txtBoxCakeName.Text, Convert.ToDecimal(txtBoxCakePrice.Text), txtBoxCakeDescription.Text, tmp, category);

            ImageUpload.SaveAs(Server.MapPath(path) + fileName);

            txtBoxCakeName.Text = "";
            txtBoxCakePrice.Text = "";
            txtBoxCakeDescription.Text = "";

            Response.Redirect("Products.aspx");
        }

        //Adds the correct item to cart when button is clicked
        protected void rptSingleCake_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                var tmp = e.CommandArgument.ToString();

                var value = ((DropDownList)e.Item.FindControl("ddQuantity")).SelectedItem.Text;

                cartUtilities.AddNewItemToCart(Convert.ToInt32(tmp), Convert.ToInt32(value));
                Response.Redirect("Products.aspx");
            }
        }
    }
}