using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace form_task
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
             
                int number1 = Convert.ToInt32(num1.Text);
                int number2 = Convert.ToInt32(num2.Text);
                int result = number1 + number2;
                lblResult.Text = result.ToString();
             
        }
        protected void btnMultiply_Click(object sender, EventArgs e)
        {
            int number1 = Convert.ToInt32(num1.Text);
            int number2 = Convert.ToInt32(num2.Text);
            int result = number1 * number2;
            lblResult.Text = result.ToString();
        }
        protected void btnSubtract_Click(object sender, EventArgs e)
        {
            int number1 = Convert.ToInt32(num1.Text);
            int number2 = Convert.ToInt32(num2.Text);
            int result = number1 - number2;
            lblResult.Text = result.ToString();
        }
    }
}