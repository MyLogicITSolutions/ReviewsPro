using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dto;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Dto;

namespace MyReviews
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCON"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    //  SqlCommand cmd = new SqlCommand("select FirstName,LastName from users where email=@email and password=@password", con)
                    Users usd = new Users();
                    string userName = username.Text;
                    SqlDataAdapter da = new SqlDataAdapter("select FirstName,LastName from users where email=@email and password=@password", con); // and password=" +password.Text+"",con);
                    da.SelectCommand.Parameters.AddWithValue("@email", userName);
                    da.SelectCommand.Parameters.AddWithValue("@password", password.Text);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        usd.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                        usd.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                        Response.Redirect("Default.aspx");
                    }
                   


                }
            }
            catch (Exception ex)
            {

            }

        }
        //protected void Login(object sender, EventArgs e)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["DBCON"].ConnectionString;
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(connectionString))
        //        {
        //            //  SqlCommand cmd = new SqlCommand("select FirstName,LastName from users where email=@email and password=@password", con)
        //            Users usd = new Users();
        //            string userName = username.Text;
        //            SqlDataAdapter da = new SqlDataAdapter("select FirstName,LastName from users where email=@email and password=@password", con); // and password=" +password.Text+"",con);
        //            da.SelectCommand.Parameters.AddWithValue("@email", userName);
        //            da.SelectCommand.Parameters.AddWithValue("@password", password.Text);
        //            DataSet ds = new DataSet();
        //            da.Fill(ds);
        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                usd.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
        //                usd.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
        //            }
        //            //    gridView.DataSource = ds;
        //            //gridView.DataBind();
        //            //  gridView.DataSource = ds;
        //            //     gridView.DataBind();


        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
    }
}