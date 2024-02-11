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
            if (!IsPostBack)
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            pnlAddStudent.Visible = true;
            pnlUpdateStudent.Visible = false;
            pnlDeleteStudent.Visible = false;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            pnlAddStudent.Visible = false;
            pnlUpdateStudent.Visible = true;
            pnlDeleteStudent.Visible = false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            pnlAddStudent.Visible = false;
            pnlUpdateStudent.Visible = false;
            pnlDeleteStudent.Visible = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AddStudent(txtAddFirstName.Text, txtAddLastName.Text);
            pnlAddStudent.Visible = false;
            BindGridView(); // Rebind GridView after adding a new record
        }
       
     
        private void AddStudent(string firstName, string lastName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            string query = "INSERT INTO Student (FirstName, LastName) VALUES (@FirstName, @LastName)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        protected void btnUpdateSave_Click(object sender, EventArgs e)
        {
            int studentID = Convert.ToInt32(txtUpdateStudentID.Text);
            string firstName = txtUpdateFirstName.Text;
            string lastName = txtUpdateLastName.Text;

            // Call the update method passing the student ID and other details
            UpdateStudent(studentID, firstName, lastName);
            pnlUpdateStudent.Visible = false;
            BindGridView();
        }

        protected void btnDeleteConfirm_Click(object sender, EventArgs e)
        {
            int studentID = Convert.ToInt32(txtDeleteStudentID.Text);

            // Call the delete method passing the student ID
            DeleteStudent(studentID);
            pnlDeleteStudent.Visible = false;
            BindGridView();
        }
        private void UpdateStudent(int studentID, string firstName, string lastName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            string query = "UPDATE Student SET FirstName = @FirstName, LastName = @LastName WHERE StudentID = @StudentID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@StudentID", studentID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void DeleteStudent(int studentID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            string query = "DELETE FROM Student WHERE StudentID = @StudentID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentID", studentID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


    }
}
