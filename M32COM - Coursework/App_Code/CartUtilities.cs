using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;

namespace M32COM___Coursework.App_Code
{
    public class CartUtilities
    {
        private HttpSessionState Session;

        public CartUtilities()
        {
            Session = HttpContext.Current.Session;
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
    }
}