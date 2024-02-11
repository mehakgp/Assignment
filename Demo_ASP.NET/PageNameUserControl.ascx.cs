using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo_ASP.NET
{
    public partial class PageNameUserControl : System.Web.UI.UserControl
    {
        public string PageName {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = PageName;
        }
    }
}