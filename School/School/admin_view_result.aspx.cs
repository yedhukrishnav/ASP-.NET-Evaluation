using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School
{
    public partial class admin_view_result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                student_BAL studentBal = new student_BAL();
                GridView1.DataSource = studentBal.viewAllStudentsResult();
                GridView1.DataBind();
            }
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}