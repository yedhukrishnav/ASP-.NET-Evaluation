using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School
{
    public partial class material_list : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=YEDHUKRISHNA\\SQLEXPRESS; Initial Catalog=dotnet_evaluation; Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                lbl_download_status.Visible = false;
                viewMaterialList();
            }
        }

        public void viewMaterialList()
        {
            SqlCommand cmd = new SqlCommand("select * from material_table", conn);
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void btn_download_Click(object sender, EventArgs e)
        {
            int matID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            SqlCommand cmd = new SqlCommand("select * from material_table where mat_id = " + matID +"", conn);
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            conn.Close();
            lbl_download_status.Visible = true;
            if (dt.Rows.Count > 0)
            {
                string fileName = dt.Rows[0]["mat_path"].ToString();
                string filePath = Server.MapPath("~/study_materials/" + fileName);

                if (System.IO.File.Exists(filePath))
                {
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                    Response.TransmitFile(filePath);
                    Response.End();
                }
                else
                {
                    lbl_download_status.Text = "Material not found.";
                }
            }
            else
            {
                lbl_download_status.Text = "Material not found.";               
            }
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}