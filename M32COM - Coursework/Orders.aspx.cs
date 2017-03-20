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
        private CartUtilities cartUtil;
        private ProductUtilities productUtil;
        private UserUtilities userUtil;

        protected void Page_Load(object sender, EventArgs e)
        {
            cartUtil = new CartUtilities();
            productUtil = new ProductUtilities();
            userUtil = new UserUtilities();

            if (IsPostBack) return;

            if (!userUtil.IsLoggedIn())
                 Response.Redirect("Login.aspx");

            Label5.Text = cartUtil.GetCartString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            cartUtil.AddNewItemToCart(productUtil.GetID(Label1.Text), Convert.ToInt32(DropDownList1.SelectedItem.Text));

            GetCartString();
            Label5.Text = Convert.ToString(cartUtil.GetTotal());

            Panel1.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            cartUtil.AddNewItemToCart(productUtil.GetID(Label2.Text), Convert.ToInt32(DropDownList2.SelectedItem.Text));

            GetCartString();
            Label5.Text = Convert.ToString(cartUtil.GetTotal());

            Panel1.Visible = true;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            cartUtil.AddNewItemToCart(productUtil.GetID(Label3.Text), Convert.ToInt32(DropDownList3.SelectedItem.Text));

            GetCartString();
            Label5.Text = Convert.ToString(cartUtil.GetTotal());

            Panel1.Visible = true;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
           if(!cartUtil.OrderCart())
                Response.Write("Not Enough Stock");

            Panel1.Visible = true;


            cartUtil.EmptyCart();

            Label5.Text = Convert.ToString(cartUtil.GetTotal());
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Clear();
            Label5.Text = Convert.ToString(cartUtil.GetTotal());
        }

        private void GetCartString()
        {
            const string label = "Cart";

            var count = 0;
            foreach (var row in cartUtil.GetCart())
            {
                var tmp = label + count;
                count++;

                var control = (Label)FindControl(tmp);
                control.Text = productUtil.GetName(row.Key) + " Quantity: " + row.Value + " at: £" + productUtil.GetPrice(row.Key) + " Item Total: £" + (productUtil.GetPrice(row.Key) * row.Value);
            }
        }

        //Temporary method to clear the labels
        private void Clear()
        {
            Panel1.Visible = false;

            cartUtil.EmptyCart();

            Cart0.Text = "";
            Cart1.Text = "";
            Cart2.Text = "";
        }
    }
}