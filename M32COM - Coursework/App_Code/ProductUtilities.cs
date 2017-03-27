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
        public bool AddProduct(string name, decimal price, string description, string image, string category)
        {
            if (ProductExists(name))
                return false;

            const string p1 = "<p>";
            const string p2 = "</p>";
            
            productDB.Product.AddProductRow(name, price, p1 + description + p2, image, category);

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
        public decimal GetPrice(int productID)
        {
            // var row = productDB.Product.Rows.Find(productID);
            var query = productDB.Product.AsEnumerable().Where(a => a.Field<int>("ProductID") == productID);

            var row = query.First();

            if (row["Price"] == null)
            {
                return 0.0M;
            }
            return Math.Round(((decimal)row["Price"] * (decimal)Session["CurrentRate"]), 2);
        }

        /// <summary>
        /// Get Price of Product from Name
        /// </summary>
        /// <param name="name">Name of Product</param>
        public decimal GetPrice(string name)
        {
            var query = productDB.Product.AsEnumerable().Where(a => a.Field<string>("Name") == name);

            var row = query.First();

            if (row["Price"] == null)
            {
                return 0.00M;
            }

            return Math.Round(((decimal)row["Price"] * (decimal)Session["CurrentRate"]), 2);
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
                    Session["CurrentRate"] = (decimal)1.0;
                    Session["CurrentFormat"] = "$";
                    break;
                case "GBP":
                    Session["CurrentRate"] = (decimal) Application["GBP"];
                    Session["CurrentFormat"] = "£";
                    break;
                case "EUR":
                    Session["CurrentRate"] = (decimal)Application["EUR"];
                    Session["CurrentFormat"] = "€";
                    break;
                default:
                    Session["CurrentRate"] = (decimal)1.0;
                    Session["CurrentFormat"] = "$";
                    break;
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