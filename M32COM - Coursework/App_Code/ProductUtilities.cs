using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.SessionState;

namespace M32COM___Coursework.App_Code
{
    public class ProductUtilities
    {
        private Database productDB;
        private const string ProductFile = "~/App_Data/Products.xml";
        private readonly HttpServerUtility Server;
        private HttpSessionState Session;
        private HttpApplicationState Application;

        public ProductUtilities()
        {
            Server = HttpContext.Current.Server;
            Session = HttpContext.Current.Session;
            Application = HttpContext.Current.Application;

            productDB = new Database();
            productDB.ReadXml(Server.MapPath(ProductFile));
        }

        /// <summary>
        /// Add a Product to Cart
        /// </summary>
        /// <param name="name">Name of Product</param>
        /// <param name="price">Price of Product</param>
        /// <param name="description">Description of Product</param>
        /// <param name="stock">Stock Count of Product</param>
        public bool AddProduct(string name, double price, string description, int stock, string image, string category)
        {
            if (ProductExists(name))
                return false;

            productDB.Product.AddProductRow(name, price, description, stock, image, category);

            productDB.Product.WriteXml(Server.MapPath(ProductFile));

            return true;
        }

        /// <summary>
        /// Remove Product from Database with given ID
        /// </summary>
        /// <param name="productID">Product ID to remove</param>
        public void RemoveProduct(int productID)
        {
            var query = productDB.Product.AsEnumerable().Where(a => a.Field<int>("ProductID") == productID);
            
            productDB.Product.RemoveProductRow(query.First());

            productDB.Product.WriteXml(Server.MapPath(ProductFile));
        }
        /// <summary>
        /// Get Price of Product from ID
        /// </summary>
        /// <param name="productID">Product ID</param>
        public double GetPrice(int productID)
        {
            // var row = productDB.Product.Rows.Find(productID);
            var query = productDB.Product.AsEnumerable().Where(a => a.Field<int>("ProductID") == productID);

            var row = query.First();

            if (row["Price"] == null)
            {
                return 0.0;
            }
            return Math.Round(((double)row["Price"] * (double)Session["CurrentRate"]), 2);
        }

        /// <summary>
        /// Get Price of Product from Name
        /// </summary>
        /// <param name="name">Name of Product</param>
        public double GetPrice(string name)
        {
            var query = productDB.Product.AsEnumerable().Where(a => a.Field<string>("Name") == name);

            var row = query.First();

            if (row["Price"] == null)
            {
                return 0.0;
            }

            return Math.Round(((double)row["Price"] * (double)Session["CurrentRate"]), 2);
        }

        /// <summary>
        /// Gets ID of Product from Name
        /// </summary>
        /// <param name="name">Name of Product</param>
        public int GetID(string name)
        {
            var query = productDB.Product.AsEnumerable().Where(a => a.Field<string>("Name") == name);

            var row = query.First();

            if (row["ProductID"] == null)
            {
                return 0;
            }

            return (int)row["ProductID"];
        }

        /// <summary>
        /// Get Name of Product from ProductID
        /// </summary>
        /// <param name="productID">Product ID</param>
        public string GetName(int productID)
        {
            var query = productDB.Product.AsEnumerable().Where(a => a.Field<int>("ProductID") == productID);

            var row = query.First();

            return (string) row["Name"];
        }

        /// <summary>
        /// Changes the Stock Value of the given Product
        /// </summary>
        /// <param name="productID">Product ID</param>
        /// <param name="quantity">Quantity to update (+-)</param>
        public bool UpdateStock(int productID, int quantity)
        {
            var query = productDB.Product.AsEnumerable().Where(a => a.Field<int>("ProductID") == productID);


            if ((query.First().Stock += quantity) < 0)
                return false;

            productDB.WriteXml(Server.MapPath(ProductFile));

            return true;
        }

        /// <summary>
        /// Checks if product exists already in database
        /// </summary>
        /// <param name="name">Name of Product</param>
        private bool ProductExists(string name)
        {
            var query = productDB.Product.AsEnumerable().Where(a => a.Field<string>("Name") == name);

            return query.Any();
        }

        //Sets currency to GBP, EUR or USD
        public bool SetCurrency(string currency)
        {
            switch (currency)
            {
                case "USD":
                    Session["CurrentRate"] = 1.0;
                    break;
                case "GBP":
                    Session["CurrentRate"] = (double) Application["GBP"];
                    break;
                case "EUR":
                    Session["CurrentRate"] = (double)Application["EUR"];
                    break;
                default:
                    return false;
            }
            return true;
        }

        //Returns the entire table
        public Database.ProductDataTable GetTable()
        {
            return productDB.Product;
        }

        //Return a filtered table
        public EnumerableRowCollection<Database.ProductRow> GetTableByCategory(string category)
        {
            return productDB.Product.AsEnumerable().Where(a => a.Field<string>("Category") == category);
        }
        
    }
}