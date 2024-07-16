using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.IO;
using System.Web.UI.WebControls;

namespace form_task
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string textToWrite = TextBox1.Text.Trim(); 
             string filePath = Server.MapPath("~/Data.txt");

            try
            {
                 using (StreamWriter writer = new StreamWriter(filePath, true))  
                {
                    writer.WriteLine(textToWrite);
                }

              
                TextBox1.Text = "";

                 
            }
            catch (Exception ex)
            {
             }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForm2.aspx");
        }
    }
}