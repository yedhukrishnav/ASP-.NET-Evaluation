using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School
{
    public partial class index : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=YEDHUKRISHNA\\SQLEXPRESS; Initial Catalog=dotnet_evaluation; Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl_error.Visible = false;
                lbl_error_photo_upload.Visible = false;
                lbl_register_result.Visible = false;
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            var email = txt_login_email.Text;
            var password = txt_login_pwd.Text;

            if (RadioButton1.Checked == true)
            {
                //two-tier
                //var account_type = "admin";

                SqlCommand cmd = new SqlCommand("admin_procedure", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("para", "login_admin");
                cmd.Parameters.AddWithValue("admin_email", email);
                cmd.Parameters.AddWithValue("admin_password", password);

                if (conn.State.Equals(ConnectionState.Closed))
                    conn.Open();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
                if (dt.Rows.Count > 0)
                {
                    //Login successful
                    Session["account_type"] = "admin";
                    Session["admin_id"] = dt.Rows[0]["admin_id"].ToString();
                    Response.Redirect("admin_home.aspx");
                }
                else
                {
                    //Login failed
                    lbl_error.Visible = true;
                    lbl_error.Text = "Invalid email or password.";
                }
            }
            else
            {
                //three-tier
                //var account_type = "student";
                Student_schema student = new Student_schema();
                student.StEmail = email;
                student.StPassword = password;

                student_BAL studentBal = new student_BAL();
                var result = studentBal.Login(student);
                if (result.Rows.Count > 0)
                {
                    //Login successful
                    Session["account_type"] = "student";
                    Session["st_register_no"] = result.Rows[0]["register_no"].ToString();
                    Response.Redirect("student_home.aspx");
                }
                else
                {
                    //Login failed
                    lbl_error.Visible = true;
                    lbl_error.Text = "Invalid email or password.";
                }
            }

            clearloginTextBoxes();
        }

        public void clearloginTextBoxes()
        {
            txt_login_email.Text = string.Empty;
            txt_login_pwd.Text = string.Empty;
            RadioButton1.Checked = false;
            RadioButton2.Checked = false;
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {

            var name = txt_name.Text;
            var age = txt_age.Text;
            var phone = txt_mobile.Text;
            var st_class = txt_class.Text;
            var email = txt_email.Text;
            var password = txt_pwd.Text;

            if (photo_student.HasFile)
            {
                photo_student.SaveAs(Server.MapPath("~/images/" + photo_student.FileName));
                lbl_error_photo_upload.Text = photo_student.FileName;

            }
            else
            {
                lbl_error_photo_upload.Visible = true;
                lbl_error_photo_upload.Text = "No file Upload";
            }
            Student_schema student = new Student_schema();
            student.StName = name;
            student.StAge = Convert.ToInt32(age);
            student.StPhone = phone;
            student.StClass = Convert.ToInt32(st_class);
            student.StProfilePhoto = photo_student.FileName;
            student.StEmail = email;
            student.StPassword = password;


            student_BAL studentBal = new student_BAL();
            int result = studentBal.registerStudent(student);
            lbl_register_result.Visible = true;
            if (result == 0)
            {
                lbl_register_result.Text = "Registration Failed";
            }
            else
            {
                lbl_register_result.Text = "Registration Successful";
                clearRegisterTextBoxes();
            }

        }

        public void clearRegisterTextBoxes()
        {
            txt_name.Text = string.Empty;
            txt_age.Text = string.Empty;
            txt_mobile.Text = string.Empty;
            txt_class.Text = string.Empty;
            txt_email.Text = string.Empty;
            txt_pwd.Text = string.Empty;
            txt_confirm_pwd.Text = string.Empty;
            photo_student.Attributes.Clear();
            lbl_error_photo_upload.Visible = false;
        }

    }
}