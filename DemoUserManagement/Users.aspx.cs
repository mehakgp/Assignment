using DemoUserManangement.BusinessLayer;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoUserManagement
{
    public partial class Users : Page
    {

        Business business = new Business();
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
            int userID = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
             Response.Redirect($"UserDetails.aspx?UserID={userID}");
        }
        
        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            Business business = new Business();
            bool success = business.DeleteUser(userID);

            if (success)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            int currentPageIndex = GridView1.PageIndex;
            int pageSize = GridView1.PageSize;
            int totalCount = GetTotalCount();

            GridView1.VirtualItemCount = totalCount;
            GetPageData(currentPageIndex, pageSize);
        }
        private int GetTotalCount()
        {
            return business.GetTotalCountUsers();
        }
        protected void PagingGridView(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridView();
        }
        public void GetPageData(int currentPageIndex, int pageSize)
        {
            string sortExpression = ViewState["SortExpression"] != null ? ViewState["SortExpression"].ToString() : "UserID";
            string sortDirection = ViewState["SortDirection"] != null ? ViewState["SortDirection"].ToString() : "ASC";

            int startIndex = currentPageIndex * pageSize + 1;
            int endIndex = startIndex + pageSize - 1;
            GridView1.DataSource = business.GetUsers(startIndex, endIndex, sortExpression, sortDirection); 
            GridView1.DataBind();
        }
        protected void SortingGridView(object sender, GridViewSortEventArgs e)
        {
            string sortDirection = "ASC";
            if (ViewState["SortDirection"] != null)
            {
                sortDirection = ViewState["SortDirection"].ToString();
                if (e.SortExpression == ViewState["SortExpression"].ToString())
                {
                    sortDirection = (sortDirection == "ASC") ? "DESC" : "ASC";
                }
            }

            ViewState["SortExpression"] = e.SortExpression;
            ViewState["SortDirection"] = sortDirection;

            BindGridView();
        }


    }

}
