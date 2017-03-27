using System;
using System.Collections.Generic;
using M32COM___Coursework.App_Code;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace M32COM___Coursework
{

    public partial class Default : System.Web.UI.Page
    {
        //Object instances
        private UserUtilities userUtil;

        protected void Page_Load(object sender, EventArgs e)
        {
            userUtil = new UserUtilities();

            if (userUtil.IsLoggedIn())
                pnlRegister.Visible = false;
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            if (userUtil.UserExists(txtBoxUserName.Text))
                Response.Write("User Exists");
            userUtil.RegisterUser(txtBoxUserName.Text, txtBoxPass.Text, txtBoxFullName.Text, txtBoxEmail.Text, txtBoxAddress.Text, "User");

            pnlRegister.Visible = false;
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string data = args.Value;
            args.IsValid = false;
            if (data.Length < 6 || data.Length > 12) return;
            bool uc = false;
            foreach (char c in data)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    uc = true; break;
                }
            }
            if (!uc) return;
            //check for lowercase
            bool lc = false;
            foreach (char c in data)
            {
                if (c >= 'a' && c <= 'z')
                {
                    lc = true; break;
                }
            }
            if (!lc) return;
            //check for numeric
            bool num = false;
            foreach (char c in data)
            {
                if (c >= '0' && c <= '9')
                {
                    num = true; break;
                }
            }
            if (!num) return;
            //must be valid
            args.IsValid = true;
        }
    }
}