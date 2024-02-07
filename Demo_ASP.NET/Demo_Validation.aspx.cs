using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo_ASP.NET
{
    public partial class Demo_Validation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SubmitButton(object sender, EventArgs e)
        {

            displayName.Text = $"Hiii {nameTextBox.Text}";

            displayEmail.Text = $"Your email id :  {emailTextBox.Text}";

            displayGender.Text = "";
            if (RadioButton1.Checked)
            {
                displayGender.Text = $"Selected Gender: {RadioButton1.Text}";
            }
            else if (RadioButton2.Checked)
            {
                displayGender.Text = $"Selected Gender: {RadioButton2.Text}";
            }

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


            if (DropDownList1.SelectedValue == "")
                displayCity.Text = "Please Select a City";
            else
                displayCity.Text = "Selected city is: " + DropDownList1.SelectedValue;
        }

        protected void PhoneNoValidate(object source, ServerValidateEventArgs args)
        {
            string phoneNumber = args.Value;

            if (!string.IsNullOrEmpty(phoneNumber) && phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

    }
}