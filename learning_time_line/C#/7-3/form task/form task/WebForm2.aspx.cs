using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


namespace form_task
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string filePath = Server.MapPath("~/Data.txt");

            try
            {
                 string fileContent = File.ReadAllText(filePath);

                 LiteralFileContent.Text = fileContent;
            }
            catch (Exception ex)
            {
                 LiteralFileContent.Text = $"Error: {ex.Message}";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForm1.aspx");
        }
    }
}