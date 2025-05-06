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
    public partial class WebForm1 : System.Web.UI.Page
    {
        Concls dbobj = new Concls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_insert";

            //input parameters
            cmd.Parameters.AddWithValue("@na", TextBox1.Text);
            cmd.Parameters.AddWithValue("@ag", TextBox2.Text);
            cmd.Parameters.AddWithValue("@addr", TextBox3.Text);
            cmd.Parameters.AddWithValue("@una", TextBox4.Text);
            cmd.Parameters.AddWithValue("@pw", TextBox5.Text);
            //output parameters
            SqlParameter sp = new SqlParameter();
            sp.DbType = DbType.Int32;
            sp.ParameterName = "@status";
            sp.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(sp);
            dbobj.Fn_nonquery(cmd);
            int outputval = Convert.ToInt32(sp.Value);
            if(outputval==1)
            {
                Label1.Text = "Inserted";
            }

        }
    }
}