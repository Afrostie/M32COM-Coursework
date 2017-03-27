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

            foreach (var item in cartUtilities.GetCart())
            {
                var tmp = productUtilities.GetName(item.Key);
                test[tmp] = item.Value;
            }
            Bind();

        }

        private void Bind()
        {
            var cartTable = cartUtilities.GetCart().AsEnumerable();
            var productTable = productUtilities.GetTable().AsEnumerable();

            var query = from cart in cartTable
                        join product in productTable on cart.Key equals product.ProductID
                        select new
                        {
                            cart.Key,
                            product.Name,
                            product.Image,
                            product.Price,
                            cart.Value,
                        };

            rptCartItem.DataSource = query;
            rptCartItem.DataBind();
        }

        protected void btnOrderCakes_Click(object sender, EventArgs e)
        {
            if(!cartUtilities.OrderCart())
                Response.Write("Please Login First");
            cartUtilities.EmptyCart();

            lblTotalPrice.Text = (string)Session["CurrentFormat"] + Convert.ToString(cartUtilities.GetTotal());

            rptCartItem.DataSource = null;
            rptCartItem.DataBind();
        }

        protected void rptCartItem_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "RemoveFromCart")
            {
                cartUtilities.RemoveItem(Convert.ToInt32(e.CommandArgument.ToString()));
                Bind();

                lblTotalPrice.Text = (string)Session["CurrentFormat"] + Convert.ToString(cartUtilities.GetTotal());
            }
        }
    }
}