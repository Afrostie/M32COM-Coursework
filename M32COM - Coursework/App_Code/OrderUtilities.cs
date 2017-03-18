using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace M32COM___Coursework.App_Code
{
    public class OrderUtilities
    {
        private Database orderDB;
        private const string OrderPath = "~/App_Data/Orders.xml";

        private HttpSessionState Session;
        private HttpServerUtility Server;

        private UserUtilities userUtil;

        public OrderUtilities()
        {
            Session = HttpContext.Current.Session;
            Server = HttpContext.Current.Server;

            userUtil = new UserUtilities();

            orderDB = new Database();
            orderDB.ReadXml(Server.MapPath(OrderPath));
        }

        //Add Order
        public void AddOrder(int productID, int quantity)
        {
            orderDB.Order.AddOrderRow(userUtil.GetUserID(), productID, quantity);

            orderDB.WriteXml(Server.MapPath(OrderPath));
        }

        //Remove Order
        public void RemoveOrder(int orderID) { }

        //Orders for user with ID
        public void GetOrderCount(int userID) { }
    }
}