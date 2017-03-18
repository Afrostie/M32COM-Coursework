using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;

namespace M32COM___Coursework.App_Code
{
    public class CartUtilities
    {
        private HttpSessionState Session;
        private ProductUtilities productUtil;
        private OrderUtilities orderUtil;

        public CartUtilities()
        {
            Session = HttpContext.Current.Session;

            productUtil = new ProductUtilities();
            orderUtil = new OrderUtilities();
        }

        //Adds a new product to cart
        public void AddNewItemToCart(int productID, int quantity)
        {
            var tmp = (Dictionary<int, int>) Session["Cart"];

            if (tmp.ContainsKey(productID))
                tmp[productID] += quantity;
            else
                tmp.Add(productID, quantity);

            Session["Cart"] = tmp;
        }

        //Change the quantity of the item in the cart
        public void UpdateQuantity(int productID, int quantity)
        {
            var tmp = (Dictionary<int, int>) Session["Cart"];

            tmp[productID] = quantity;

            Session["Cart"] = tmp;
        }

        //Clears the cart of any products
        public void EmptyCart()
        {
            var tmp = (Dictionary<int, int>) Session["Cart"];
            tmp.Clear();

            Session["Cart"] = tmp;
        }

        //Returns the amount of items in the cart
        public int GetItemCount()
        {
            var tmp = (Dictionary<int, int>) Session["Cart"];
            return tmp.Count;
        }

        //Returns the quantity of items for a given id in the cart
        public int GetQuantity(int productID)
        {
            var tmp = (Dictionary<int, int>) Session["Cart"];

            return tmp[productID];
        }

        //Removes given product from cart
        public bool RemoveItem(int productID)
        {
            var tmp = (Dictionary<int, int>) Session["Cart"];

            return tmp.Remove(productID);
        }

        //Returns the entire cart in a Dictionary
        public Dictionary<int, int> GetCart()
        {
            var tmp = (Dictionary<int, int>) Session["Cart"];

            return tmp;
        }

        //Debug method, returns ID and quantity of each item in cart in a string
        public string GetCartString()
        {
            var cart = GetCart();

            string total = "";

            foreach (var item in cart)
            {
                string tmp = item.Key + " x " + item.Value + "\n";
                total += tmp;
            }
            return total;
        }

        //Get the total price of the cart
        public double GetTotal()
        {
            var cart = GetCart();

            var total = 0.0;

            foreach (var item in cart)
            {
                total += (productUtil.GetPrice(item.Key) * item.Value);
            }
            return total;
        }

        //Adds all items in cart to Orders database
        public bool OrderCart()
        {
            var cart = GetCart();

            foreach (var item in cart)
            {
                if (!orderUtil.AddOrder(item.Key, item.Value))
                    return false;
            }
            return true;
        }
    }
}