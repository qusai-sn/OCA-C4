using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace form_task
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string name = txtName.Text;
            string email = txtEmail.Text;
            string id = txtID.Text;
            string gender = genderRadio.SelectedItem != null ? genderRadio.SelectedItem.Text : "";

            List<string> selectedCourses = new List<string>();
            foreach (ListItem item in courseCheckboxes.Items)
            {
                if (item.Selected)
                {
                    selectedCourses.Add(item.Value);
                }
            }
            string courses = string.Join(", ", selectedCourses);

            string desc = txtDescription.Text;


            lblName.Text = name;
            lblEmail.Text = email;
            lblID.Text = id;
            lblGender.Text = gender;
            lblCourses.Text = courses;
            lblDescription.Text = desc;
        }
    }
    }
