using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoUserManagement
{
    public partial class LogOut : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Session.Remove("UserSessionInfo");
            Session.Abandon();
            Response.Redirect("~/LogIn.aspx");
        }
    }
}