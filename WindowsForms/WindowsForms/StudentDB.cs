using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms
{
    class StudentDB
    {
        string SQLConnection;
        private string getConnection()
        {
            return ConfigurationManager.ConnectionStrings["student"].ConnectionString;
        }
        public DataTable GetStudentList()
        {
            string SQL = "select * from student";
            SqlConnection cn = new SqlConnection(getConnection());
            SqlCommand cmd = new SqlCommand(SQL, cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                if(cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                    
                }
                da.Fill(dt);
            }
            catch (Exception)
            {

                throw new Exception();
            }
            finally
            {
                cn.Close();
            }
            return dt;
        }
        public bool Add(Students st)
        {   bool r;
            string SQL = "insert into Student values(@ID,@Name,@Age,@Class)";
            SqlConnection cn = new SqlConnection(getConnection());
            SqlCommand cmd = new SqlCommand(SQL, cn);
            cmd.Parameters.AddWithValue("@ID", st.ID);
            cmd.Parameters.AddWithValue("@Name", st.Name);
            cmd.Parameters.AddWithValue("@Age", st.Age);
            cmd.Parameters.AddWithValue("@Class", st.Class);
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                    
                }
                r = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {

                throw new Exception();
            }
            finally
            {
                cn.Close();
            }
            return r;
        }
        public bool Update(Students st)
        {
            bool r;
            string SQL = "Update student set, Name = @Name, Age = @Age, Class= @Class WHERE ID = @ID";
            SqlConnection cn = new SqlConnection(getConnection());
            SqlCommand cmd = new SqlCommand(SQL, cn);
            cmd.Parameters.AddWithValue("@ID", st.ID);
            cmd.Parameters.AddWithValue("@Name", st.Name);
            cmd.Parameters.AddWithValue("@Age", st.Age);
            cmd.Parameters.AddWithValue("@Class", st.Class);
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();

                }
                r = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {

                throw new Exception();
            }
            finally
            {
                cn.Close();
            }
            return r;
        }
        public bool Delete(Students st)
        {
            bool r;
            string SQL = "Delete Student Where ID= @ID";
            SqlConnection cn = new SqlConnection(getConnection());
            SqlCommand cmd = new SqlCommand(SQL, cn);
            cmd.Parameters.AddWithValue("@ID", st.ID);           
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();

                }
                r = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception)
            {

                throw new Exception();
            }
            finally
            {
                cn.Close();
            }
            return r;
        }
    }
}
