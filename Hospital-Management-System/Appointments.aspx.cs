using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT365_Assignment2
{
    public partial class Appointments : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetPatient();
            GetTreatment();
            ShowAppointment();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-793HLGI;Initial Catalog=HospitalDb;User ID=mh;Password=12345678");

        private void ShowAppointment()
        {
            conn.Open();
            string Query = "select * from Appointment";
            SqlDataAdapter Sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(Sda);
            var dataSet = new DataSet();
            Sda.Fill(dataSet);
            AppointmentGV.DataSource = dataSet.Tables[0];
            AppointmentGV.DataBind();
            conn.Close();
        }

        private void GetPatient()
        {
            conn.Open();
            string Query = "select * from Patient";
            SqlDataAdapter Sda = new SqlDataAdapter(Query, conn);
            DataSet dataSet = new DataSet();
            Sda.Fill(dataSet);
            PatientDDL.DataTextField = dataSet.Tables[0].Columns["PatientName"].ToString();
            PatientDDL.DataValueField = dataSet.Tables[0].Columns["PatientID"].ToString();
            PatientDDL.DataSource = dataSet.Tables[0];
            PatientDDL.DataBind();
            conn.Close();
        }

        private void GetTreatment()
        {
            conn.Open();
            string Query = "select * from Treatment";
            SqlDataAdapter Sda = new SqlDataAdapter(Query, conn);
            DataSet dataSet = new DataSet();
            Sda.Fill(dataSet);
            TreatmentDDL.DataTextField = dataSet.Tables[0].Columns["TreatName"].ToString();
            TreatmentDDL.DataValueField = dataSet.Tables[0].Columns["TreatID"].ToString();
            TreatmentDDL.DataSource = dataSet.Tables[0];
            TreatmentDDL.DataBind();
            conn.Close();
        }

        int Key = 0;
        protected void AppointmentGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            PatientDDL.SelectedValue = AppointmentGV.SelectedRow.Cells[2].Text;
            TreatmentDDL.SelectedValue = AppointmentGV.SelectedRow.Cells[3].Text;
            ApTime.SelectedValue = AppointmentGV.SelectedRow.Cells[5].Text;

            if (PatientDDL.DataTextField == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(AppointmentGV.SelectedRow.Cells[1].Text);
            }
        }

        private void InsertAppointment()
        {
            if (PatientDDL.SelectedIndex == -1 || TreatmentDDL.SelectedIndex == -1 || ApTime.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Missing Data')", true);
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into Appointment values(@PDDL,@TDDL,@AD,@AT)", conn);
                    cmd.Parameters.AddWithValue("@PDDL", PatientDDL.SelectedValue); //DDL is drop down list
                    cmd.Parameters.AddWithValue("@TDDL", TreatmentDDL.SelectedValue);
                    cmd.Parameters.AddWithValue("@AD", ApDate.Value);
                    cmd.Parameters.AddWithValue("@AT", ApTime.SelectedValue);

                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Appointment Inserted')", true);
                    conn.Close();
                    ShowAppointment();
                }
                catch (Exception Ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Appointment Insert Unsuccessfully')", true);
                }

            }
        }

        private void EditAppointment()
        {
            if (PatientDDL.SelectedIndex == -1 || TreatmentDDL.SelectedIndex == -1 || ApTime.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Missing Data')", true);
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Update Appointment set Patient=@P,Treatment=@T,ApDate=@AD,ApTime=@AT,where ApID=@PKey", conn);
                    cmd.Parameters.AddWithValue("@PDDL", PatientDDL.SelectedValue); //DDL is drop down list
                    cmd.Parameters.AddWithValue("@TDDL", TreatmentDDL.SelectedValue);
                    cmd.Parameters.AddWithValue("@AD", ApDate.Value);
                    cmd.Parameters.AddWithValue("@AT", ApTime.SelectedValue);
                    cmd.Parameters.AddWithValue("@PKey", AppointmentGV.SelectedRow.Cells[1].Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Appointment Updated')", true);
                    conn.Close();
                    ShowAppointment();
                }
                catch (Exception Ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Appointment Updated Unsuccessfully')", true);
                }

            }
        }

        private void DeleteAppointment()
        {
            if (PatientDDL.SelectedIndex == -1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Select Appointment')", true);
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from Appointment where ApID=@PKey", conn);
                    cmd.Parameters.AddWithValue("@PKey", AppointmentGV.SelectedRow.Cells[1].Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Appointment Deleted')", true);
                    conn.Close();
                    ShowAppointment();
                }
                catch (Exception Ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Appointment Delete Unsuccessfully')", true);
                }

            }
        }

        protected void ApEditBtn_Click(object sender, EventArgs e)
        {
            EditAppointment();
        }

        protected void ApAddBtn_Click(object sender, EventArgs e)
        {
            InsertAppointment();
        }

        protected void ApDeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteAppointment();
        }
    }
}