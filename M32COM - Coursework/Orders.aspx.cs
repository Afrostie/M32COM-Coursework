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

            BuildPage();
            UpdateCartString();
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
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            cartUtilities.AddNewItemToCart(productUtilities.GetID(CakeName1.Text), Convert.ToInt32(Quantity1.SelectedValue));
            UpdateCartString();
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            cartUtilities.AddNewItemToCart(productUtilities.GetID(CakeName2.Text), Convert.ToInt32(Quantity2.SelectedValue));
            UpdateCartString();
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            cartUtilities.AddNewItemToCart(productUtilities.GetID(CakeName3.Text), Convert.ToInt32(Quantity3.SelectedValue));
            UpdateCartString();
        }

        public void BuildPage()
        {
            int i = 1;
            const string CakeName = "CakeName";
            const string CakeDescripion = "CakeDesc";
            const string PanelName = "Panel";
            foreach (var row in productUtilities.ReturnTable())
            {
                var panel = (Panel)FindControl(PanelName + i);
                var cakeName = (Label)FindControl(CakeName + i);
                var cakeDescription = (Label)FindControl(CakeDescripion + i);

                cakeName.Text = row.Name;
                cakeDescription.Text = row.Description;
                panel.Visible = true;

                i++;
            }
        }

        public void UpdateCartString()
        {
            var count = 1;
            const string label = "Cart";
            CartLabel.Text = Convert.ToString(count);

            foreach(var row in cartUtilities.GetCart())
            {
                var newLabel = (Label)FindControl(label + count);

                newLabel.Text = productUtilities.GetName(row.Key) + " Quantity: " + row.Value + " at: £" + productUtilities.GetPrice(row.Key) + " Item Total: £" + (productUtilities.GetPrice(row.Key) * row.Value);

                count++;
            }

            Total.Text = "Total: " + Convert.ToString(cartUtilities.GetTotal());
        }

        protected void OrderButton_Click(object sender, EventArgs e)
        {
            ClearScreen();
            cartUtilities.OrderCart();
            
        }

        protected void ClearButton_Click(object sender, EventArgs e)
        {
            ClearScreen();

            cartUtilities.EmptyCart();

            UpdateCartString();
        }

        protected void ClearScreen()
        {
            Quantity1.SelectedIndex = 0;
            Quantity2.SelectedIndex = 0;
            Quantity3.SelectedIndex = 0;

            Cart1.Text = "";
            Cart2.Text = "";
            Cart3.Text = "";
            Cart4.Text = "";
        }
    }
}