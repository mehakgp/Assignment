using System;
using System.Web.UI.WebControls;
using static DemoUserManagement.UtilityLayer.Utility;
using DemoUserManangement.BusinessLayer;

namespace DemoUserManagement
{
    public partial class NoteUserControl : System.Web.UI.UserControl
    {

   
        public int ObjectID { get; set; }
        public int ObjectType { get; set; }


        Business business = new Business();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ObjectID!=0)
                {
                    ViewState["ObjectID"] = ObjectID;
                    ViewState["ObjectType"] = ObjectType;
                    LoadNotes();
                }
            }
        }

        protected void LoadNotes()
        {
            if (business.NoteExists((int)ViewState["ObjectID"], (int)ViewState["ObjectType"]))
            {
                BindGridView();
            }
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
                InsertNote();
                LoadNotes();
            
        }

        protected void InsertNote()
        {

            business.InsertNote((int)ViewState["ObjectID"], (int)ViewState["ObjectType"], noteTextBox.Text);
        }

        private int GetTotalCount()
        {
            return business.GetTotalCount((int)ViewState["ObjectID"], (int)ViewState["ObjectType"]);
        }

        private void BindGridView()
        {
            int currentPageIndex = GridView1.PageIndex;
            int pageSize = GridView1.PageSize;
            int totalCount = GetTotalCount();

            GridView1.VirtualItemCount = totalCount;
            GetPageData(currentPageIndex, pageSize);
        }

        protected void PagingGridView(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadNotes();
        }

        public void GetPageData(int currentPageIndex, int pageSize)
        {
           
            string sortExpression = ViewState["SortExpression"] != null ? ViewState["SortExpression"].ToString() : "ID";
            string sortDirection = ViewState["SortDirection"] != null ? ViewState["SortDirection"].ToString() : "ASC";
            int startIndex = currentPageIndex * pageSize + 1;
            int endIndex = startIndex + pageSize - 1;
            GridView1.DataSource = business.GetNotes((int)ViewState["ObjectID"], (int)ViewState["ObjectType"], startIndex, endIndex,sortExpression,sortDirection);
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
            LoadNotes();
        }


    }
}