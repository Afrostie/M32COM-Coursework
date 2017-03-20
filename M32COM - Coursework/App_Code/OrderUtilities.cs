using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Data;

namespace M32COM___Coursework.App_Code
{
    public class OrderUtilities
    {
        private Database orderDB;
        private const string OrderPath = "~/App_Data/Orders.xml";

        private HttpSessionState Session;
        private HttpServerUtility Server;

        private UserUtilities userUtil;
        private ProductUtilities productUtil;

        public OrderUtilities()
        {
            Session = HttpContext.Current.Session;
            Server = HttpContext.Current.Server;

            userUtil = new UserUtilities();
            productUtil = new ProductUtilities();

            orderDB = new Database();
            orderDB.ReadXml(Server.MapPath(OrderPath));
        }

        /// <summary>
        /// Add Order to the Database
        /// </summary>
        /// <param name="productID">Product ID to add</param>
        /// <param name="quantity">Quantity of product</param>
        public bool AddOrder(int productID, int quantity)
        {
            if(!productUtil.UpdateStock(productID, quantity * -1))
                return false;

            orderDB.Order.AddOrderRow(userUtil.GetUserID(), productID, quantity);

            orderDB.WriteXml(Server.MapPath(OrderPath));

            return true;
        }

        //Remove Order
        public void RemoveOrder(int orderID) { }

        /// <summary>
        /// Returns Number of times a product has been ordered
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int GetOrderCount(int userID)
        {
            var query = orderDB.Order.AsEnumerable().Where(a => a.Field<int>("UserID") == userID);

            return query.Count();
        }

        public EnumerableRowCollection<Database.OrderRow> GetOrdersByCustomer(int userID)
        {
            var query = orderDB.Order.AsEnumerable().Where(a => a.Field<int>("UserID") == userID);

            return query;
        }
    }
}