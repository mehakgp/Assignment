using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo_ASP.NET
{
    public partial class Demo_WebForm : System.Web.UI.Page
    {
        protected System.Web.UI.HtmlControls.HtmlInputFile File1;
        protected System.Web.UI.HtmlControls.HtmlInputSubmit Submit1;
        protected void SubmitButton(object sender, EventArgs e)
        {
            //name display
            displayName.Text = $"Hiii {TextBox1.Text}";

            //file uploaded message
            if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
            {
                string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                string SaveLocation = Server.MapPath("upload") + "\\" + fn;
                try
                {
                    FileUpload1.PostedFile.SaveAs(SaveLocation);
                    FileUploadStatus.Text = "The file has been uploaded.";
                }
                catch (Exception ex)
                {
                    FileUploadStatus.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                FileUploadStatus.Text = "Please select a file to upload.";
            }


            //gender display
            displayGender.Text = "";
            if (RadioButton1.Checked)
            {
                displayGender.Text = $"Selected Gender: {RadioButton1.Text}";
            }
            else if (RadioButton2.Checked)
            {
                displayGender.Text = $"Selected Gender: {RadioButton2.Text}";
            }

            //date display
            displayDate.Text = "Selected Date: " + Calendar1.SelectedDate.ToString("D");


            //course display
            var message = "Selected Courses: ";
            if (CheckBox1.Checked)
            {
                message += CheckBox1.Text + ",";
            }
            if (CheckBox2.Checked)
            {
                message += CheckBox2.Text + ",";
            }
            if (CheckBox3.Checked)
            {
                message += CheckBox3.Text;
            }
            displayCourse.Text = message;


            //dropdown for city
            if (DropDownList1.SelectedValue == "")
                displayCity.Text = "Please Select a City";
            else
                displayCity.Text = "Selected city is: " + DropDownList1.SelectedValue;
        }


        protected void LinkButtonClicked(object sender, EventArgs e)
        {
            displayLinkButton.Text = "Checking link buttton....";
        }

    }
}