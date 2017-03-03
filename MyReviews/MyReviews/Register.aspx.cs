using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dto;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MyReviews
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Users userObj = new Users();
            userObj.FirstName = txtFirstName.Text;
            userObj.LastName = txtLastName.Text;
            userObj.Gender = ddlGender.SelectedIndex.ToString();
            userObj.MobileNumber = Int64.Parse(txtMobilenumber.Text); 
            txtMobilenumber.Text = Int32.MaxValue.ToString();
            userObj.Password = txtPassword.Text;
            userObj.Email = txtEmail.Text;
            userObj.City = DDL3.SelectedIndex.ToString();
            userObj.Country = DDL1.SelectedIndex.ToString();
            userObj.Adress = txtAddress.Text;
            userObj.DateofBirth =Convert.ToDateTime(txtDob.Text);
            Users retobj = Register1(userObj);
        }

        public Users Register1(Users obj)
        {
            Users retObj = new Users();
            string connectionString = ConfigurationManager.ConnectionStrings["DBCON"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("RegisterUsers", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@firstName", obj.FirstName);
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
                        int dbkey = Convert.ToInt32(cmd.ExecuteScalar());
                        if (dbkey != 0)
                        {
                            txtResult.InnerText = "Success";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return retObj;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}