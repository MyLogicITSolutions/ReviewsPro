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
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Display();

        }
        public List<Users> Display()
        {
            Users retObj = new Users();
            string connectionString = ConfigurationManager.ConnectionStrings["DBCON"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from Users", con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        gridView.DataSource = ds;
                        gridView.DataBind();

                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
           


            return null;
        }
    }
}