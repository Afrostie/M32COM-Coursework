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
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            if (userUtil.UserExists(txtBoxUserName.Text))
                Response.Write("User Exists");
            userUtil.RegisterUser(txtBoxUserName.Text, txtBoxPass.Text, txtBoxFullName.Text, txtBoxEmail.Text, txtBoxAddress.Text, "User");

            pnlRegister.Visible = false;
        }
    }
}