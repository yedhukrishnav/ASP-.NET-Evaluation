using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School
{
    public partial class student_home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GridView1.Visible = false;
                update_error_lbl.Visible = false;
                lbl_profile_update.Visible = false;
                fillDetails(); 
            }
        }

        public void fillDetails()
        {
            var studentID = Convert.ToInt32(Session["st_register_no"]);

            student_BAL studentBal = new student_BAL();
            DataTable dt = new DataTable();
            dt = studentBal.GetStudentDetailsByID(studentID);

            if(dt.Rows.Count > 0)
            {
                txt_name.Text = dt.Rows[0]["st_name"].ToString();
                txt_age.Text = dt.Rows[0]["st_age"].ToString();
                txt_mobile.Text = dt.Rows[0]["st_phoneNum"].ToString();
                txt_class.Text = dt.Rows[0]["st_class"].ToString();
                img_profile.ImageUrl = "images/" + dt.Rows[0]["st_photo"].ToString();
                txt_email.Text = dt.Rows[0]["st_email"].ToString();
                txt_old_password.Text = dt.Rows[0]["st_password"].ToString();
                Session["old_password"] = dt.Rows[0]["st_password"].ToString();
                Session["old_image_name"] = dt.Rows[0]["st_photo"].ToString();
            }
        }
        protected void btn_update_changes_Click(object sender, EventArgs e)
        {
            var name = txt_name.Text;
            var age = txt_age.Text;
            var mobile = txt_mobile.Text;
            var className = Convert.ToInt32(txt_class.Text);
            var email = txt_email.Text;
            var oldPassword = Session["old_password"].ToString();
            var newPassword = txt_new_password.Text;

            string finalPassword;
            if (string.IsNullOrEmpty(newPassword) || newPassword == oldPassword)
            {
                finalPassword = oldPassword;
            }
            else
            {
                finalPassword = newPassword;
            }
            if (img_profile_update.HasFile)
            {
                img_profile_update.SaveAs(Server.MapPath("~/images/" + img_profile_update.FileName));
                lbl_profile_update.Text = img_profile_update.FileName;

            }
            else
            {
                lbl_profile_update.Visible = true;
                lbl_profile_update.Text = "No file Upload";
            }

            Student_schema student = new Student_schema
            {
                RegisterNo = Convert.ToInt32(Session["st_register_no"]),
                StName = name,
                StAge = Convert.ToInt32(age),
                StPhone = mobile,
                StClass = className,
                StEmail = email,
                StPassword = finalPassword,
                StProfilePhoto = img_profile_update.HasFile ? img_profile_update.FileName : Session["old_image_name"].ToString()
            };

            student_BAL studentBal = new student_BAL();
            int result = studentBal.updateStudentDetails(student);
            update_error_lbl.Visible = true;
            if (result == 0)
            {
                update_error_lbl.Text = "Error in updating details. Please try again.";
            }
            else
            {
                lbl_profile_update.Visible = false;
                update_error_lbl.Text = "Profile updated successfully!";
                fillDetails();
            }
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void btn_scoreboard_Click(object sender, EventArgs e)
        {
            if(btn_scoreboard.Text == "Hide Scoreboard")
            {
                GridView1.Visible = false;
                btn_scoreboard.Text = "Show Scoreboard";
            }
            else
            {
                GridView1.Visible = true;
                btn_scoreboard.Text = "Hide Scoreboard";
                var std_regNo = Convert.ToInt32(Session["st_register_no"]);

                student_BAL studentBal = new student_BAL();
                DataTable dt = new DataTable();
                dt = studentBal.viewResultByID(std_regNo);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }


        }

        protected void btn_materials_Click(object sender, EventArgs e)
        {
            Response.Redirect("material_list.aspx");
        }
    }
}