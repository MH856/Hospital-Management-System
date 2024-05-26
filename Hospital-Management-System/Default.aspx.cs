using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT365_Assignment2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-793HLGI;Initial Catalog=HospitalDb;User ID=mh;Password=12345678");
        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            if(Email.Value == "MHadmin@gmail.com" && Password.Value == "MHAdmin@31")
            {
                ErrMsg.InnerText = "Correct Details";
                Response.Redirect("Patient.aspx");
            }
            else
            {
                ErrMsg.Visible = true;
            }
        }
    }
}