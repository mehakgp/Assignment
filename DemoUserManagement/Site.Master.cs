using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoUserManagement
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PageTitleLiteral.Text = Page.Title;

            var currentPage = System.IO.Path.GetFileName(Request.Url.AbsolutePath);


            if (currentPage == "UserDetails.aspx")
            {
                UserDetailsLink.Attributes["class"] += " selected";
            }
            else if (currentPage == "Users")
            {
                UsersListLink.Attributes["class"] += " selected";
            }
        }
    }
}
