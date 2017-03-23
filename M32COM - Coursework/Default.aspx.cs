using System;
using System.Collections.Generic;
using M32COM___Coursework.App_Code;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Default : System.Web.UI.Page
{
    private XDocument contentDoc;
    public XDocument ContentDoc
    {
        get
        {
            if (contentDoc == null)
            {
                return contentDoc = XDocument.Load(Server.MapPath("~/App_Data/content.xml"));
            }
            return contentDoc;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindPageContent();
        }
    }

        /*protected void BindPageContent()
        {
            List<XElement> xContent = ContentDoc.Descendants("content").ToList<XElement>();
            rptMainContent.DataSource =
                xContent.ToList().Where(item => item.Attribute("frontPage").Value.Contains("true")).Select(s => new
                {
                    PostTitle = s.Attribute("title").Value,
                    PostContent = s.Value,
                });
            rptMainContent.DataBind();
        }*/

        protected void Register_Click(object sender, EventArgs e)
        {
            if (userUtilities.UserExists(TextBox1.Text))
                Response.Write("User Exists");
            userUtilities.RegisterUser(TextBox1.Text, TextBox2.Text, TextBox4.Text, TextBox3.Text, TextBox5.Text, "User");

            pnlRegister.Visible = false;
        }
    }

    protected void Register_Click(object sender, EventArgs e)
    {
        if (userUtil.UserExists(TextBox1.Text))
            Response.Write("User Exists");
        userUtil.RegisterUser(TextBox1.Text, TextBox2.Text, TextBox4.Text, TextBox3.Text, TextBox5.Text, "User");
    }
}