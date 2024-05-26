using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT365_Assignment2
{
    public partial class Patient : Page
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-793HLGI;Initial Catalog=HospitalDb;User ID=mh;Password=12345678");
        private void ShowPatients()
        {
            conn.Open();
            string Query = "select * from Patient";
            SqlDataAdapter Sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(Sda);
            var dataSet = new DataSet();
            Sda.Fill(dataSet);
            PatientGV.DataSource = dataSet.Tables[0];
            PatientGV.DataBind();
            conn.Close();
        }
        private void InsertPatient()
        {
            if(PatientName.Value == "" || PatientPhone.Value == "" || PatientAddress.Value == "" || PatientDOB.Value == "" || PatientGender.Value == "" || PatientAllergies.Value == "" )
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Missing Data')", true);
            }else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into Patient values(@PN,@PP,@PA,@PD,@PG,@PA1)", conn);
                    cmd.Parameters.AddWithValue("@PN", PatientName.Value);
                    cmd.Parameters.AddWithValue("@PP", PatientPhone.Value);
                    cmd.Parameters.AddWithValue("@PA", PatientAddress.Value);
                    cmd.Parameters.AddWithValue("@PD", PatientDOB.Value);
                    cmd.Parameters.AddWithValue("@PG", PatientGender.Value);
                    cmd.Parameters.AddWithValue("@PA1", PatientAllergies.Value);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Patient Inserted')", true);
                    conn.Close();
                    ShowPatients();
                }
                catch(Exception Ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Data Insert Unsuccessfully')", true);
                }

            }
        }

        private void EditPatient()
        {
            if (PatientName.Value == "" || PatientPhone.Value == "" || PatientAddress.Value == "" || PatientDOB.Value == "" || PatientGender.Value == "" || PatientAllergies.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Missing Data')", true);
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Update Patient set PatientName=@PN,PatientPhone=@PP,PatientAddress=@PA,PatientDOB=@PD,PatientGender=@PG,PatientAllergies=@PA1 where PatientID=@PKey", conn);
                    cmd.Parameters.AddWithValue("@PN", PatientName.Value);
                    cmd.Parameters.AddWithValue("@PP", PatientPhone.Value);
                    cmd.Parameters.AddWithValue("@PA", PatientAddress.Value);
                    cmd.Parameters.AddWithValue("@PD", PatientDOB.Value);
                    cmd.Parameters.AddWithValue("@PG", PatientGender.Value);
                    cmd.Parameters.AddWithValue("@PA1", PatientAllergies.Value);
                    cmd.Parameters.AddWithValue("@PKey", PatientGV.SelectedRow.Cells[1].Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Patient Updated')", true);
                    conn.Close();
                    ShowPatients();
                }
                catch (Exception Ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Patient Update Unsuccessfully')", true);
                }

            }
        }

        private void DeletePatient()
        {
            if (PatientName.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Select Patient to Delete')", true);
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from Patient where PatientID=@PKey", conn);
                    cmd.Parameters.AddWithValue("@PKey", PatientGV.SelectedRow.Cells[1].Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Patient Deleted')", true);
                    conn.Close();
                    ShowPatients();
                }
                catch (Exception Ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Patient Delete Unsuccessfully')", true);
                }

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowPatients();
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            InsertPatient();
        }

        int Key = 0;
        protected void PatientGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            PatientName.Value = PatientGV.SelectedRow.Cells[2].Text;
            PatientPhone.Value = PatientGV.SelectedRow.Cells[3].Text;
            PatientAddress.Value = PatientGV.SelectedRow.Cells[4].Text;
            PatientGender.Value = PatientGV.SelectedRow.Cells[6].Text;
            PatientAllergies.Value = PatientGV.SelectedRow.Cells[7].Text;
            if(PatientName.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(PatientGV.SelectedRow.Cells[1].Text);
            }

        }

        protected void EditBtnn_Click(object sender, EventArgs e)
        {
            EditPatient();
        }

        protected void DeleteBtnn_Click(object sender, EventArgs e)
        {
            DeletePatient();
        }
    }
}