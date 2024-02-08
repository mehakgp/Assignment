using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo_ASP.NET
{
    public partial class GridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
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
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Student", connection))
                {
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }
        protected void InsertButton(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Student (FirstName, LastName) VALUES (@FirstName, @LastName)";
                cmd.Parameters.AddWithValue("@FirstName", TextBox1.Text);
                cmd.Parameters.AddWithValue("@LastName", TextBox2.Text);
                cmd.ExecuteNonQuery();
                Response.Redirect("GridView.aspx");
            }
        }
        protected void ResetButton(object sender, EventArgs e)
        {

            TextBox1.Text = "";
            TextBox2.Text = "";
        }


        protected void PagingGridView(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridView(); // Rebind data on page change
        }

        public void GetPageData(int currentPageIndex, int pageSize)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                string sortExpression = ViewState["SortExpression"] != null ? ViewState["SortExpression"].ToString() : "StudentID";
                string sortDirection = ViewState["SortDirection"] != null ? ViewState["SortDirection"].ToString() : "ASC";

        
                string query = string.Format(@"SELECT * FROM (
                                            SELECT ROW_NUMBER() OVER (ORDER BY {0} {1}) AS RowNum, * 
                                            FROM Student
                                        ) AS Students 
                                        WHERE RowNum BETWEEN @StartIndex AND @EndIndex", sortExpression, sortDirection);

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int startIndex = currentPageIndex * pageSize + 1;
                    int endIndex = startIndex + pageSize - 1;

                    command.Parameters.AddWithValue("@StartIndex", startIndex);
                    command.Parameters.AddWithValue("@EndIndex", endIndex);

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

            BindGridView();
        }


    }
}