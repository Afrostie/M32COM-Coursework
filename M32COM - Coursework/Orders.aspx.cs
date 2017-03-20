using System;
using System.Collections.Generic;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            cartUtilities = new CartUtilities();
            productUtilities = new ProductUtilities();
            userUtilities = new UserUtilities();

            if (IsPostBack) return;

            if (!userUtilities.IsLoggedIn())
                 Response.Redirect("Login.aspx");

            Label5.Text = cartUtilities.GetCartString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            cartUtilities.AddNewItemToCart(productUtilities.GetID(Label1.Text), Convert.ToInt32(DropDownList1.SelectedItem.Text));

            GetCartString();
            Label5.Text = Convert.ToString(cartUtilities.GetTotal());

            Panel1.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            cartUtilities.AddNewItemToCart(productUtilities.GetID(Label2.Text), Convert.ToInt32(DropDownList2.SelectedItem.Text));

            GetCartString();
            Label5.Text = Convert.ToString(cartUtilities.GetTotal());

            Panel1.Visible = true;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            cartUtilities.AddNewItemToCart(productUtilities.GetID(Label3.Text), Convert.ToInt32(DropDownList3.SelectedItem.Text));

            GetCartString();
            Label5.Text = Convert.ToString(cartUtilities.GetTotal());

            Panel1.Visible = true;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
           if(!cartUtilities.OrderCart())
                Response.Write("Not Enough Stock");

            Panel1.Visible = true;


            cartUtilities.EmptyCart();

            Label5.Text = Convert.ToString(cartUtilities.GetTotal());
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Clear();
            Label5.Text = Convert.ToString(cartUtilities.GetTotal());
        }

        private void GetCartString()
        {
            const string label = "Cart";

            var count = 0;
            foreach (var row in cartUtilities.GetCart())
            {
                var tmp = label + count;
                count++;

                var control = (Label)FindControl(tmp);
                control.Text = productUtilities.GetName(row.Key) + " Quantity: " + row.Value + " at: £" + productUtilities.GetPrice(row.Key) + " Item Total: £" + (productUtilities.GetPrice(row.Key) * row.Value);
            }
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