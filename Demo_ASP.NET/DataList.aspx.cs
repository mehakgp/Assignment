using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo_ASP.NET
{
    public partial class DataList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {          
            //datalist
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Name");
            table.Columns.Add("Email");
            table.Rows.Add("101", "Sachin Kumar", "sachin@example.com");
            table.Rows.Add("102", "Peter", "peter@example.com");
            table.Rows.Add("103", "Ravi Kumar", "ravi@example.com");
            table.Rows.Add("104", "Irfan", "irfan@example.com");
            DataList1.DataSource = table;
            DataList1.DataBind();

            //datagrid
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                SqlDataAdapter sde = new SqlDataAdapter("Select * from student", con);
                DataSet ds = new DataSet();
                sde.Fill(ds);
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();
            }  
        }
    }
}