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

namespace MyReviews
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            productName.InnerText = "Samsung S7 Edge";
            Display();
            //txtuserName.InnerText = "Sai Lokesh";
            //txtComments.InnerText = "this is the best mobile i've seen till now";
            //txtDate.InnerText = "03/03/2017";
        }
        public List<Reviews> Display()
        {
            Users retObj = new Users();
            string connectionString = ConfigurationManager.ConnectionStrings["DBCON"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("select * from reviews", con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                       
                        da.Fill(ds);

                        DataList1.DataSource = ds;
                        DataList1.DataBind();

                        //listofReviews.DataSource = ds;
                        //listofReviews.DataBind();
                        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        //{
                        //   txtuserName.InnerText = ds.Tables[i].Rows[i]["FirstName"].ToString()+ ds.Tables[i].Rows[i]["LastName"].ToString();
                        //   txtComments.InnerText = ds.Tables[i].Rows[i]["comments"].ToString();
                        //   txtDate.InnerText= ds.Tables[i].Rows[i]["dor"].ToString();
                        //}
                        //trying to set these values to user object but I'm not getting it in default.aspx


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