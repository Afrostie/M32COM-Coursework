using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using M32COM___Coursework.App_Code;

namespace M32COM___Coursework
{
    public partial class Admin : System.Web.UI.Page
    {
        private OrderUtilities orderUtilities;
        private ProductUtilities productUtilities;
        private UserUtilities userUtilities;

        protected void Page_Load(object sender, EventArgs e)
        {
            orderUtilities = new OrderUtilities();
            productUtilities = new ProductUtilities();
            userUtilities = new UserUtilities();

            if (!IsPostBack)
            {
                DropDownList1.DataSource = orderUtilities.GetAllUserID();
                DropDownList1.DataBind();
            }
           
            //GridView1.Visible = true;

            if (!(userUtilities.IsLoggedIn() && userUtilities.GetUserRole() == "Admin"))
                Response.Redirect("Default.aspx");

            //Bind(3);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
             Bind(Convert.ToInt32(DropDownList1.SelectedItem.Text));
            
           // Response.Redirect(this.Page.Request.FilePath);
        }

        private void Bind(int ID)
        {
            var productTable = productUtilities.GetTable();
            var orderTable = orderUtilities.GetTable();
            var userTable = userUtilities.GetTable();

            var query = from product in productTable
                        join order in orderTable on product.ProductID equals order.ProductID
                        join user in userTable on order.UserID equals user.UserID
                        where order.UserID == ID
                        select new
                        {
                            UserName = user.Name,
                            order.OrderID,
                            product.Name,
                            product.Price,
                            order.Quantity
                        };

            //GridView1.Visible = true;
            GridView1.DataSource = query;
            GridView1.DataBind();
        }
    }
}