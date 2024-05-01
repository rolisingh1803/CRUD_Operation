using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CRUDOperationInMVC.Models
{
    public class StudentDBHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["Studentconn"].ToString();
            con = new SqlConnection(constring);
        }

        public bool AddStudent(Student smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("Addnewstudent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@firstname", smodel.FirstName);
            cmd.Parameters.AddWithValue("@lastname", smodel.LastName);
            cmd.Parameters.AddWithValue("@dob", smodel.DOB);
            cmd.Parameters.AddWithValue("@address", smodel.Address);
            cmd.Parameters.AddWithValue("@emailid", smodel.EmailId);
            cmd.Parameters.AddWithValue("phonenumber", smodel.PhoneNumber);
            cmd.Parameters.AddWithValue("@gender", smodel.Gender);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public List<Student> GetStudents()
        {
            connection();

            List<Student> StudentList = new List<Student>();

            SqlCommand cmd = new SqlCommand("getstudentdetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                StudentList.Add(
                    new Student
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        FirstName = Convert.ToString(dr["firstname"]),
                        LastName = Convert.ToString(dr["lastname"]),
                        DOB = Convert.ToDateTime(dr["dob"]),
                        Address = Convert.ToString(dr["address"]),
                        EmailId = Convert.ToString(dr["emailid"]),
                        PhoneNumber = Convert.ToString(dr["phonenumber"]),
                        Gender = Convert.ToString(dr["gender"])

                    });
            }
            return StudentList;
        }

        public bool Updatedetails(Student smodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("updatestudentdeatils", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@stdid", smodel.Id);
            cmd.Parameters.AddWithValue("@firstname", smodel.FirstName);
            cmd.Parameters.AddWithValue("@lastname", smodel.LastName);
            cmd.Parameters.AddWithValue("@dob", smodel.DOB);
            cmd.Parameters.AddWithValue("@address", smodel.Address);
            cmd.Parameters.AddWithValue("@emailid", smodel.EmailId);
            cmd.Parameters.AddWithValue("@phonenumber", smodel.PhoneNumber);
            cmd.Parameters.AddWithValue("@gender", smodel.Gender);


            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool deletestudent(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("deletestudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@stdid", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    }
      
    
