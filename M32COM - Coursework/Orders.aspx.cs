using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using M32COM___Coursework.App_Code;

namespace M32COM___Coursework
{
    public partial class Orders : System.Web.UI.Page
    {
        private CartUtilities cartUtilities;
        private ProductUtilities productUtilities;
        private UserUtilities userUtilities;

        //TODO: Link Category Buttons together

        protected void Page_Load(object sender, EventArgs e)
        {
            cartUtilities = new CartUtilities();
            productUtilities = new ProductUtilities();
            userUtilities = new UserUtilities();

            if (IsPostBack) return;

            lblTotalPrice.Text = (string)Session["CurrentFormat"] + Convert.ToString(cartUtilities.GetTotal());

            var test = new Dictionary<string, int>();

            if (userUtilities.GetUserRole() == "Admin")
                pnlAdmin.Visible = true;

            foreach (var item in cartUtilities.GetCart())
            {
                var tmp = productUtilities.GetName(item.Key);
                test[tmp] = item.Value;
            }

            var cartTable = cartUtilities.GetCart().AsEnumerable();
            var productTable = productUtilities.GetTable().AsEnumerable();

            var query = from cart in cartTable
                        join product in productTable on cart.Key equals product.ProductID
                        select new
                        {
                            product.Name,
                            product.Image,
                            product.Price,
                            cart.Value,
                        };

            rptCartItem.DataSource = query;
            rptCartItem.DataBind();
        }

        protected void AddOrder1_Click(object sender, EventArgs e)
        {
            cartUtilities.AddNewItemToCart(productUtilities.GetID(lblCake1.Text), Convert.ToInt32(DropDownList1.SelectedItem.Text));

            //GetCartString();
            lblTotal.Text = Convert.ToString(cartUtilities.GetTotal());

            Panel1.Visible = true;
        }

        protected void AddOrder2_Click(object sender, EventArgs e)
        {
            cartUtilities.AddNewItemToCart(productUtilities.GetID(lblCake2.Text), Convert.ToInt32(DropDownList2.SelectedItem.Text));

            //GetCartString();
            lblTotal.Text = Convert.ToString(cartUtilities.GetTotal());

            Panel1.Visible = true;
        }

        protected void AddOrder3_Click(object sender, EventArgs e)
        {
            cartUtilities.AddNewItemToCart(productUtilities.GetID(lblCake3.Text), Convert.ToInt32(DropDownList3.SelectedItem.Text));

            //GetCartString();
            lblTotal.Text = Convert.ToString(cartUtilities.GetTotal());

            Panel1.Visible = true;
        }

        protected void OrderCart_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;


            cartUtilities.EmptyCart();

            lblTotal.Text = Convert.ToString(cartUtilities.GetTotal());
        }

        protected void ClearCart_Click(object sender, EventArgs e)
        {
            Clear();
            lblTotal.Text = Convert.ToString(cartUtilities.GetTotal());
        }

        //Temporary method to clear the labels
        private void Clear()
        {
            Panel1.Visible = false;

            cartUtilities.EmptyCart();

            Cart0.Text = "";
            Cart1.Text = "";
            Cart2.Text = "";
        }
    }
}