using DemoUserManangement.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static DemoUserManagement.ModelView.Model;
using static DemoUserManagement.UtilityLayer.Utility;

namespace DemoUserManagement
{
    public partial class DocumentUserControl : System.Web.UI.UserControl
    {
        public int ObjectID { get; set; }
        public int ObjectType { get; set; }
        public int DocumentType { get; set; }

        Business business = new Business();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["ObjectID"] = ObjectID;
                ViewState["ObjectType"] = ObjectType;

                ddlDocumentType.DataSource = GetDocumentTypes(ObjectType);
                ddlDocumentType.DataTextField = "DocumentTypeName";
                ddlDocumentType.DataValueField = "DocumentId";
                ddlDocumentType.DataBind();
                LoadDocuments();

                hdnObjectID.Value = ObjectID.ToString();
                hdnObjectType.Value = ObjectType.ToString();
            }


        }

        protected void LoadDocuments()
        {
            if (business.DocumentExists((int)ViewState["ObjectID"], (int)ViewState["ObjectType"]))
            {
                GetDocumentData();
            }
        }


        protected void ButtonClick(object sender, EventArgs e)
        {
            LoadDocuments();
        }

        protected void GetDocumentData()
        {
            List<DocumentModel> doc = business.GetDocuments((int)ViewState["ObjectID"], (int)ViewState["ObjectType"]);
            GridView1.DataSource = doc;
            GridView1.DataBind();
        }

        protected void ddlDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DocumentType = int.Parse(ddlDocumentType.SelectedValue);
            hdnDocumentType.Value = DocumentType.ToString();

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DownloadFile")
            {
                int documentId = Convert.ToInt32(e.CommandArgument);
                int userId = (int)ViewState["ObjectID"];
                string url = $"DownloadFile.ashx?documentID={documentId}&userID={userId}";
                Response.Redirect(url);
            }
        }

    }
}