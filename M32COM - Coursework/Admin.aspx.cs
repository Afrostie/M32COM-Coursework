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


            DropDownList1.DataSource = orderUtilities.GetAllUserID();
            DropDownList1.DataBind();
            GridView1.Visible = true;

            if (!(userUtilities.IsLoggedIn() && userUtilities.GetUserRole() == "Admin"))
                Response.Redirect("Default.aspx");

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Bind(int ID)
        {
            var tmp3 = productUtilities.GetTable();
            var tmp4 = orderUtilities.GetTable();

            var query = from m in tmp3
                        join g in tmp4 on m.ProductID equals g.ProductID
                        where g.UserID == ID
                        select new
                        {
                            g.OrderID, m.Name, m.Price, g.Quantity
                        };

            GridView1.Visible = true;
            GridView1.DataSource = query;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Bind(Convert.ToInt32(DropDownList1.SelectedItem.Text));
        }
    }
}