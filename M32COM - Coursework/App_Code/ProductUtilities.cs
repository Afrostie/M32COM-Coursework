using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Data;

namespace M32COM___Coursework.App_Code
{
    public class ProductUtilities
    {
        private Database productDB;
        private const string ProductFile = "~/App_Data/Products.xml";
        private readonly HttpServerUtility Server;

        public ProductUtilities()
        {
            Server = HttpContext.Current.Server;

            productDB = new Database();
            productDB.ReadXml(Server.MapPath(ProductFile));
        }

        //Add Product To Database
        public bool AddProduct(string name, double price, string description, int stock)
        {
            if (!ProductExists(name))
                return false;

            productDB.Product.AddProductRow(name, price, description, stock);

            productDB.Product.WriteXml(Server.MapPath(ProductFile));

            return true;
        }

        //Remove product from database
        public void RemoveProduct(int id)
        {
            var query = productDB.Product.AsEnumerable().Where(a => a.Field<int>("ProductID") == id);
            
            productDB.Product.RemoveProductRow(query.First());

            productDB.Product.WriteXml(Server.MapPath(ProductFile));
        }
        //Get price from ID (overload with name)
        public double GetPrice(int id)
        {
            var row = productDB.Product.Rows.Find(id);

            if (row["Price"] == null)
            {
                return 0.0;
            }

            return (double)row["Price"];
        }

        public double GetPrice(string name)
        {
            var query = productDB.Product.AsEnumerable().Where(a => a.Field<string>("Name") == name);

            var row = query.First();

            if (row["Price"] == null)
            {
                return 0.0;
            }

            return (double)row["Price"];
        }

        //Update stock of item from ID (overload with name)
        public void UpdateStock(int id)
        {

        }

        //Check if product exists
        private bool ProductExists(string name)
        {
            var query = productDB.Product.AsEnumerable().Where(a => a.Field<string>("Name") == name);

            return query.Any();
        }
    }
}