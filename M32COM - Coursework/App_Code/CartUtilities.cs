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

        /// <summary>
        /// Add a new product to the cart
        /// </summary>
        /// <param name="productID">Product ID</param>
        /// <param name="quantity">Product Quantity</param>
        public void AddNewItemToCart(int productID, int quantity)
        {
            var tmp = (Dictionary<int, int>) Session["Cart"];

            if (tmp.ContainsKey(productID))
                tmp[productID] += quantity;
            else
                tmp.Add(productID, quantity);

            Session["Cart"] = tmp;
        }

        /// <summary>
        /// Update Quantity of Product in Cart
        /// </summary>
        /// <param name="productID">Product ID</param>
        /// <param name="quantity">Quantity</param>
        public void UpdateQuantity(int productID, int quantity)
        {
            var tmp = (Dictionary<int, int>) Session["Cart"];

            tmp[productID] = quantity;

            Session["Cart"] = tmp;
        }

        /// <summary>
        /// Empties the Cart of all Items
        /// </summary>
        public void EmptyCart()
        {
            var tmp = (Dictionary<int, int>) Session["Cart"];
            tmp.Clear();

            Session["Cart"] = tmp;
        }

        /// <summary>
        /// Gets the amount of items in the cart
        /// </summary>
        public int GetItemCount()
        {
            var tmp = (Dictionary<int, int>) Session["Cart"];
            return tmp.Count;
        }

        /// <summary>
        /// Gets Quantity of chosen Product from Cart
        /// </summary>
        /// <param name="productID">Product ID</param>
        public int GetQuantity(int productID)
        {
            var tmp = (Dictionary<int, int>) Session["Cart"];

            return tmp[productID];
        }

        /// <summary>
        /// Remove specified item from cart
        /// </summary>
        /// <param name="productID">Product ID</param>
        public bool RemoveItem(int productID)
        {
            var tmp = (Dictionary<int, int>) Session["Cart"];

            return tmp.Remove(productID);
        }

        /// <summary>
        /// Returns the Entire cart, useful for iterating through
        /// </summary>
        public Dictionary<int, int> GetCart()
        {
            var tmp = (Dictionary<int, int>) Session["Cart"];

            return tmp;
        }

        /// <summary>
        /// Useless method to return the Cart as a String
        /// </summary>
        public string GetCartString()
        {
            var cart = GetCart();

            var total = "";

            foreach (var item in cart)
            {
                string tmp = item.Key + " x " + item.Value + "\n";
                total += tmp;
            }
            return total;
        }

        /// <summary>
        /// Returns total of Cart
        /// </summary>
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

        /// <summary>
        /// Orders all items currently in the cart to the current user
        /// </summary>
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