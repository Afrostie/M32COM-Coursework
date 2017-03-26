using System;
using System.Collections.Generic;
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

        private XDocument productsDoc;
        public XDocument ProductsDoc
        {
            get
            {
                if (productsDoc == null)
                {
                    return productsDoc = XDocument.Load(Server.MapPath("~/App_Data/products.xml"));
                }
                return productsDoc;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            productUtil = new ProductUtilities();
            userUtil = new UserUtilities();

            if (IsPostBack) return;

            if (userUtil.GetUserRole() == "Admin")
                pnlAdmin.Visible = true;

            rptSingleCake.DataSource = productUtil.ReturnTable();
            rptSingleCake.DataBind();
        }

        protected void AddCake_Click(object sender, EventArgs e)
        {
            productUtil.AddProduct(txtBoxCakeName.Text, Convert.ToDouble(txtBoxCakePrice.Text), txtBoxCakeDescription.Text,
                Convert.ToInt32(txtBoxCakeStock.Text), txtBoxCakeImage.Text);

            txtBoxCakeName.Text = "";
            txtBoxCakePrice.Text = "";
            txtBoxCakeDescription.Text = "";
            txtBoxCakeStock.Text = "";
            txtBoxCakeImage.Text = "";
        }
    }
}