using DemoUserManagement.UtilityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static DemoUserManagement.ModelView.Model;

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


            if (!IsPostBack)
            {
                CheckUserRole();
                HideLogoutLink();

            }
        }
        private void CheckUserRole()
        {
            if (Utility.GetUserSessionInfo() != null)
            {
                UserDetailsLink.Visible = Utility.IsAdmin();
                UsersListLink.Visible = Utility.IsAdmin();
            }
            else
            {
                UserDetailsLink.Visible = false;
                UsersListLink.Visible = false;
            }
        }

        private void HideLogoutLink()
        {
            if (Utility.GetUserSessionInfo() == null)
                LogoutLink.Visible = false;
            else 
                LogoutLink.Visible=true;

        }
    }
}
