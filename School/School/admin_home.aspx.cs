using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School
{
    public partial class admin_home : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=YEDHUKRISHNA\\SQLEXPRESS; Initial Catalog=dotnet_evaluation; Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl_material_name.Visible = false;
                lbl_marks_error.Visible = false;
                lbl_mat_error.Visible = false;
                ViewRegisteredStudentList();
            }
        }

        public void ViewRegisteredStudentList()
        {
            student_BAL studentBal = new student_BAL();
            GridView1.DataSource = studentBal.ViewRegisteredStudents();
            GridView1.DataBind();
        }

        protected void btn_set_marks_Click(object sender, EventArgs e)
        {
            int reg_no = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Session["student_regNo"] = reg_no;
            SqlCommand cmd = new SqlCommand("select * from student_table where register_no= " + reg_no + "", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                txt_student_name.Text = dt.Rows[0][1].ToString();
            }
        }

        protected void btn_add_marks_Click(object sender, EventArgs e)
        {
            var student_reg_no = Convert.ToInt32(Session["student_regNo"]);
            int maths_marks = Convert.ToInt32(txt_maths_marks.Text);
            int english_marks = Convert.ToInt32(txt_english_marks.Text);
            int java_marks = Convert.ToInt32(txt_java_marks.Text);
            int cpp_marks = Convert.ToInt32(txt_cpp_marks.Text);
            int total_marks = maths_marks + english_marks + java_marks + cpp_marks;
            string query = "insert into marks_table values('" + student_reg_no + "', " + maths_marks + ", '" + english_marks + "', '" + java_marks + "', '" + cpp_marks + "', '" + total_marks + "')";
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();

            lbl_marks_error.Visible = true;
            if (result == 0)
            {
                lbl_marks_error.Text = "Failed to add marks. Please try again.";
            }
            else
            {
                lbl_marks_error.Text = "Marks added successfully.";

                txt_student_name.Text = string.Empty;
                txt_maths_marks.Text = "";
                txt_english_marks.Text = "";
                txt_java_marks.Text = "";
                txt_cpp_marks.Text = "";
            }
        }

        protected void btn_view_all_results_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_view_result.aspx");
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("index.aspx");
        }

        protected void btn_materials_upload_Click(object sender, EventArgs e)
        {
            if (file_study_materials.HasFile)
            {
                file_study_materials.SaveAs(Server.MapPath("~/study_materials/" + file_study_materials.FileName));
                lbl_material_name.Text = file_study_materials.FileName;
                var mat_name = txt_material_name.Text;

                SqlCommand cmd = new SqlCommand("INSERT INTO material_table values ('" + lbl_material_name.Text + "', '" + mat_name + "')", conn);
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();
                lbl_mat_error.Visible = true;
                if (result == 0)
                {
                    lbl_mat_error.Text = "Failed to upload material. Please try again.";
                }
                else
                {
                    lbl_mat_error.Text = "Material uploaded successfully: " + lbl_material_name.Text;
                    txt_material_name.Text = string.Empty;
                }
            }
            else
            {
                lbl_material_name.Visible = true;
                lbl_material_name.Text = "No file to Upload.";
            }
        }
    }
}