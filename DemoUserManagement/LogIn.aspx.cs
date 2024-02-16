using DemoUserManangement.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoUserManagement
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Please enter UserID and Password.";
                lblMessage.Visible = true;
                return;
            }

            Business business = new Business();
            int userID = business.GetUserByEmailAndPassword(email, password);

            if (userID == -1)
            {
                lblMessage.Text = "Invalid UserID or Password.";
                lblMessage.Visible = true;
                return;
            }
            else
            {

                bool isAdmin = business.CheckIfUserIsAdmin(userID);
                Session["isAdmin"] = isAdmin;
                Session["UserID"] = userID;
                if (isAdmin)
                {
                    Response.Redirect("~/Users.aspx");
                }
                else
                {
                    Response.Redirect($"~/UserDetails.aspx?UserID={Session["UserID"]}");
                }
            }
        }
    }
}
