using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace StoredProcedure
{
    public partial class ProfileView : System.Web.UI.Page
    {
        Concls dbobj = new Concls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_UserProfile";

                //input parameters
                cmd.Parameters.AddWithValue("@id", Session["uid"]);
                SqlDataReader dr = dbobj.Fn_Reader(cmd);
                while (dr.Read())
                {
                    TextBox1.Text = dr["Name"].ToString();
                    TextBox2.Text = dr["Age"].ToString();
                    TextBox3.Text = dr["Address"].ToString();
                    TextBox4.Text = dr["Username"].ToString();

                }
                DataSet ds = dbobj.Fn_Adapter(cmd);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_ProfileUpdate";

            //input parameters
            cmd.Parameters.AddWithValue("@id", Session["uid"]);
            cmd.Parameters.AddWithValue("@ag", TextBox2.Text);
            cmd.Parameters.AddWithValue("@addr", TextBox3.Text);
            dbobj.Fn_nonquery(cmd);
        }
    }
}








  