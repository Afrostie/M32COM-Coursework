using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool AddItemToCart(int id)
        {
            var tmp = (List<int>) Session["Cart"];
            tmp.Add(id);

            Session["Cart"] = tmp;

            return true;
        }

        public int GetCount()
        {
            var tmp = (List<int>)Session["Cart"];
            return tmp.Count;
        }
    }
}