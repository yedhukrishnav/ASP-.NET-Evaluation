using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace School
{
    public class student_DAL
    {
        SqlConnection conn = new SqlConnection("Data Source=YEDHUKRISHNA\\SQLEXPRESS; Initial Catalog=dotnet_evaluation; Integrated Security=True");
        SqlCommand cmd;
        DataTable dt;

        public DataTable login(Student_schema student)
        {
            using (cmd = new SqlCommand("student_procedure", conn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("para", "login_student");
                    cmd.Parameters.AddWithValue("st_email", student.StEmail);
                    cmd.Parameters.AddWithValue("st_password", student.StPassword);

                    if (conn.State.Equals(ConnectionState.Closed))
                        conn.Open();

                    dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    conn.Close();
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public int registerStudent(Student_schema student)
        {
            using (cmd = new SqlCommand("student_procedure", conn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("para", "register_student");
                    cmd.Parameters.AddWithValue("st_name", student.StName);
                    cmd.Parameters.AddWithValue("st_age", student.StAge);
                    cmd.Parameters.AddWithValue("st_phoneNum", student.StPhone);
                    cmd.Parameters.AddWithValue("st_class", student.StClass);
                    cmd.Parameters.AddWithValue("st_photo", student.StProfilePhoto);
                    cmd.Parameters.AddWithValue("st_email", student.StEmail);
                    cmd.Parameters.AddWithValue("st_password", student.StPassword);

                    if (conn.State.Equals(ConnectionState.Closed))
                        conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public DataTable ViewRegisteredStudents()
        {
            using (cmd = new SqlCommand("student_procedure", conn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("para", "view_registered_students");
                    if (conn.State.Equals(ConnectionState.Closed))
                        conn.Open();
                    dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public DataTable viewAllStudentsResult()
        {
            using (cmd = new SqlCommand("student_procedure", conn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("para", "view_all_students_result");
                    if (conn.State.Equals(ConnectionState.Closed))
                        conn.Open();
                    dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public DataTable GetStudentDetailsByID(int studentID)
        {
            using (cmd = new SqlCommand("student_procedure", conn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("para", "get_student_details_by_id");
                    cmd.Parameters.AddWithValue("register_no", studentID);
                    if (conn.State.Equals(ConnectionState.Closed))
                        conn.Open();
                    dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public int UpdateStudentDetails(Student_schema student)
        {
            using (cmd = new SqlCommand("student_procedure", conn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("para", "update_By_ID");
                    cmd.Parameters.AddWithValue("register_no", student.RegisterNo);
                    cmd.Parameters.AddWithValue("st_name", student.StName);
                    cmd.Parameters.AddWithValue("st_age", student.StAge);
                    cmd.Parameters.AddWithValue("st_phoneNum", student.StPhone);
                    cmd.Parameters.AddWithValue("st_class", student.StClass);
                    cmd.Parameters.AddWithValue("st_photo", student.StProfilePhoto);
                    cmd.Parameters.AddWithValue("st_email", student.StEmail);
                    cmd.Parameters.AddWithValue("st_password", student.StPassword);

                    if (conn.State.Equals(ConnectionState.Closed))
                        conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public DataTable viewResultByID(int stdID)
        {
            using (cmd = new SqlCommand("student_procedure", conn))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("para", "view_result_by_id");
                    cmd.Parameters.AddWithValue("register_no", stdID);
                    if (conn.State.Equals(ConnectionState.Closed))
                        conn.Open();
                    dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}