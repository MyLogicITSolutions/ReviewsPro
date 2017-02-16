using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;

namespace Dmo
{
    public class Reviews
    {
        public Users Register(Users obj)
        {
            Users retObj = new Users();
            string connectionString = ConfigurationManager.ConnectionStrings["DBCON"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("RegisterUsers",con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@firstName",obj.FirstName);
                        cmd.Parameters.AddWithValue("@lastName", obj.LastName);
                        cmd.Parameters.AddWithValue("@email", obj.Email);
                        cmd.Parameters.AddWithValue("@mobile", obj.MobileNumber);
                        cmd.Parameters.AddWithValue("@Gender", obj.Gender);
                        cmd.Parameters.AddWithValue("@address", obj.Adress);
                        cmd.Parameters.AddWithValue("@dob", obj.DateofBirth);
                        cmd.Parameters.AddWithValue("@country", obj.Country);
                        cmd.Parameters.AddWithValue("@city", obj.City);
                        cmd.Parameters.AddWithValue("@password", obj.Password);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                return null;
            }
            return retObj;
        }
    }
}
