using DemoUserManangement.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static DemoUserManagement.ModelView.Model;

namespace DemoUserManagement
{
    public partial class Users : Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserDetails.aspx");
        }

        protected void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int userId = Convert.ToInt32(gvUsers.DataKeys[e.NewEditIndex].Value);
            Response.Redirect($"UserDetails.aspx?UserId={userId}");
        }

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userId = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);
            Business business = new Business();
            bool success = business.DeleteUser(userId);

            if (success)
            {
                BindGridView();
            }
            else
            {
                // Handle delete failure
            }
        }

        private void BindGridView()
        {
            Business business = new Business();
            List<GridViewUserDetailsModel> users = business.GetUsers();
            gvUsers.DataSource = users;
            gvUsers.DataBind();
        }
    }
}
