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

        public bool AddNewItemToCart(int id, int quantity)
        {
            var tmp = (Dictionary<int, int>) Session["Cart"];

            if (tmp.ContainsKey(id))
                return false;

            tmp.Add(id, quantity);

            Session["Cart"] = tmp;

            return true;
        }

        public void UpdateQuantity(int id, int quantity)
        {
            var tmp = (Dictionary<int, int>)Session["Cart"];

            tmp[id] = quantity;

            Session["Cart"] = tmp;
        }

        public void EmptyCart()
        {
            var tmp = (Dictionary<int, int>)Session["Cart"];
            tmp.Clear();

            Session["Cart"] = tmp;
        }

        public int GetItemCount()
        {
            var tmp = (Dictionary<int, int>)Session["Cart"];
            return tmp.Count;
        }

        public int GetQuantity(int id)
        {
            var tmp = (Dictionary<int, int>)Session["Cart"];

            return tmp[id];
        }

        public bool RemoveItem(int id)
        {
            var tmp = (Dictionary<int, int>)Session["Cart"];

            return tmp.Remove(id);
        }

        public Dictionary<int, int> GetCart()
        {
            var tmp = (Dictionary<int, int>)Session["Cart"];

            return tmp;
        }

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

        public double GetTotal()
        {
            var cart = GetCart();

            double total = 0.0;

            foreach (var item in cart)
            {
                total += (productUtil.GetPrice(item.Key) * item.Value);
            }
            return total;
        }

        public void OrderCart()
        {
            var cart = GetCart();

            foreach (var item in cart)
            {
                orderUtil.AddOrder(item.Key, item.Value);
            }
        }
    }
}