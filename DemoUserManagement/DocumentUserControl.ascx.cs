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
            InsertDocument();
            LoadDocuments();
        }

        protected void InsertDocument()
        {
            string fileName = "", fileExtension, uniqueFileName = "", uploadFolderPath = "", filePath = "";
            if (document.HasFile && (int)ViewState["DocumentType"]!=0)
            {
                fileName = document.FileName;
                fileExtension = Path.GetExtension(fileName);
                uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
                uploadFolderPath = ConfigurationManager.AppSettings["DocumentFilePath"];
                filePath = Path.Combine(uploadFolderPath, uniqueFileName);
                document.SaveAs(filePath);

                var doc = new DocumentModel
                {
                    ObjectID = (int)ViewState["ObjectID"],
                    ObjectType = (int)ViewState["ObjectType"],
                    DocumentType = (int)ViewState["DocumentType"],
                    DocumentOriginalName = fileName,
                    DocumentUniqueName = uniqueFileName
                };
                Business business = new Business();
                business.SaveDocument(doc);
            }
        }

        public void GetDocumentData()
        {
            List<DocumentModel> doc = business.GetDocuments((int)ViewState["ObjectID"], (int)ViewState["ObjectType"]);
            GridView1.DataSource = doc;
            GridView1.DataBind();
        }

        protected void ddlDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DocumentType = int.Parse(ddlDocumentType.SelectedValue);
            ViewState["DocumentType"] = DocumentType;

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DownloadFile")
            {
                string fileName = e.CommandArgument.ToString();
                string url = "DownloadFile.ashx?fileName=" + fileName;
                Response.Redirect(url);
            }
        }

    }
}