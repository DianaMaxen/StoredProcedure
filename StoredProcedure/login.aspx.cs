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
    public partial class login : System.Web.UI.Page
    {
        Concls dbobj = new Concls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_login";

            //input parameters
            cmd.Parameters.AddWithValue("@una", TextBox1.Text);
            cmd.Parameters.AddWithValue("@pw", TextBox2.Text);
            string cid = dbobj.Fn_scalar(cmd);
            if(cid=="1")
            {
                SqlCommand cmd1 = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_GetId";

                //input parameters
                cmd1.Parameters.AddWithValue("@una", TextBox1.Text);
                cmd1.Parameters.AddWithValue("@pw", TextBox2.Text);
                string id= dbobj.Fn_scalar(cmd1);
                Session["uid"] = id;
                Response.Redirect("ProfileView.aspx");
            }
            else
            {
                Label1.Text = "Invalid username and password";
            }
        }
    }
}