using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoUserManagement
{
    public partial class NoteUserControl: System.Web.UI.UserControl
    {
      
        public string PageName { get; set; }
        public int ObjectID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["UserID"]))
                {
                  
                    ObjectID = Convert.ToInt32(Request.QueryString["UserID"]);
                    LoadNotes();
                }
            }
        }

        protected void LoadNotes()
        {
            if (NoteExists(ObjectID))
            {
                BindGridView();
            }
        }

        protected bool NoteExists(int objectID)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Notes WHERE ObjectID = @ObjectID AND ObjectType = @ObjectType", conn);
                cmd.Parameters.AddWithValue("@ObjectID", objectID);
                cmd.Parameters.AddWithValue("@ObjectType", PageName);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["UserID"]))
            {
                ObjectID = Convert.ToInt32(Request.QueryString["UserID"]);
                InsertNote();
                LoadNotes();
            }
        }

        protected void InsertNote()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Notes (ObjectID, ObjectType, Note, DateTime) VALUES (@ObjectID, @ObjectType, @Note, @DateTime)", conn);
                cmd.Parameters.AddWithValue("@ObjectID", ObjectID);
                cmd.Parameters.AddWithValue("@ObjectType", PageName);
                cmd.Parameters.AddWithValue("@Note", noteTextBox.Text);
                cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }

        private int GetTotalCount()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Notes  WHERE ObjectID = @ObjectID AND ObjectType = @ObjectType", connection))
                {
                    command.Parameters.AddWithValue("@ObjectID", ObjectID);
                    command.Parameters.AddWithValue("@ObjectType", PageName);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
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

        protected void PagingGridView(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

            if (!string.IsNullOrEmpty(Request.QueryString["UserID"]))
            {
                ObjectID = Convert.ToInt32(Request.QueryString["UserID"]);
            }
            LoadNotes();
        }

        public void GetPageData(int currentPageIndex, int pageSize)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                string sortExpression = ViewState["SortExpression"] != null ? ViewState["SortExpression"].ToString() : "ID";
                string sortDirection = ViewState["SortDirection"] != null ? ViewState["SortDirection"].ToString() : "ASC";


                string query = string.Format(@"SELECT * FROM (
                                SELECT ROW_NUMBER() OVER (ORDER BY {0} {1}) AS RowNum, * 
                                FROM Notes
                                WHERE ObjectID = @ObjectID AND ObjectType = @ObjectType
                            ) AS Notes 
                            WHERE RowNum BETWEEN @StartIndex AND @EndIndex", sortExpression, sortDirection);

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int startIndex = currentPageIndex * pageSize + 1;
                    int endIndex = startIndex + pageSize - 1;

                    command.Parameters.AddWithValue("@StartIndex", startIndex);
                    command.Parameters.AddWithValue("@EndIndex", endIndex);
                    command.Parameters.AddWithValue("@ObjectID", ObjectID);
                    command.Parameters.AddWithValue("@ObjectType", PageName);

                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }

            }
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


            if (!string.IsNullOrEmpty(Request.QueryString["UserID"]))
            {
                ObjectID = Convert.ToInt32(Request.QueryString["UserID"]);
            }
            LoadNotes();
        }


    }
}