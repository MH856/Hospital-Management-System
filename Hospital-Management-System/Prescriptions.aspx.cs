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
    public partial class Prescriptions : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetPatient();
            GetTreatment();
            ShowPrescriptions();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-793HLGI;Initial Catalog=HospitalDb;User ID=mh;Password=12345678");

        private void ShowPrescriptions()
        {
            conn.Open();
            string Query = "select * from Prescription";
            SqlDataAdapter Sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(Sda);
            var dataSet = new DataSet();
            Sda.Fill(dataSet);
            PrescriptionGV.DataSource = dataSet.Tables[0];
            PrescriptionGV.DataBind();
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

        private void GetCost()
        {
            conn.Open();
            string Query = "select * from Treatment where TreatID="+TreatmentDDL.SelectedValue+"";
            SqlCommand cmd = new SqlCommand(Query, conn);            
            DataTable dataTable = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter(cmd);
            Sda.Fill(dataTable);
            foreach (DataRow dr in dataTable.Rows)
            {
                TreatCost.Value = dr["TreatCost"].ToString();
            }
            conn.Close();
        }

        protected void PatientDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }  
        
        protected void TreatmentDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCost();
        }

        private void InsertPrescription()
        {
            if (Medicines.Value == "" || MedQty.Value == "" || TreatCost.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Missing Data')", true);
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into Prescription values(@PDDL,@TDDL,@TC,@M,@MQ)", conn);
                    cmd.Parameters.AddWithValue("@PDDL", PatientDDL.SelectedValue); //DDL is drop down list
                    cmd.Parameters.AddWithValue("@TDDL", TreatmentDDL.SelectedValue);
                    cmd.Parameters.AddWithValue("@TC", TreatCost.Value);
                    cmd.Parameters.AddWithValue("@M", Medicines.Value);
                    cmd.Parameters.AddWithValue("@MQ", MedQty.Value);

                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Prescription Inserted')", true);
                    conn.Close();
                    ShowPrescriptions();
                }
                catch (Exception Ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Prescription Insert Unsuccessfully')", true);
                }

            }
        }

        private void EditPrescription()
        {
            if (PatientDDL.SelectedValue == "" || TreatmentDDL.SelectedValue == "" || TreatCost.Value == "" || Medicines.Value == "" || MedQty.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Missing Data')", true);
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Update Prescription set Patient=@PDDL,Treatment=@TDDL,TreatCost=@TC,Medicines=@M,MedQty=@MQ where PrescID=@PKey", conn);
                    cmd.Parameters.AddWithValue("@PDDL", PatientDDL.SelectedValue); //DDL is drop down list
                    cmd.Parameters.AddWithValue("@TDDL", TreatmentDDL.SelectedValue);
                    cmd.Parameters.AddWithValue("@TC", TreatCost.Value);
                    cmd.Parameters.AddWithValue("@M", Medicines.Value);
                    cmd.Parameters.AddWithValue("@MQ", MedQty.Value);
                    cmd.Parameters.AddWithValue("@PKey", PrescriptionGV.SelectedRow.Cells[1].Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Prescription Updated')", true);
                    conn.Close();
                    ShowPrescriptions();
                }
                catch (Exception Ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Prescription Update Unsuccessfully')", true);
                }

            }
        }

        private void DeletePrescription()
        {
            if (Medicines.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Select Prescription to Delete')", true);
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from Prescription where PrescID=@PKey", conn);
                    cmd.Parameters.AddWithValue("@PKey", PrescriptionGV.SelectedRow.Cells[1].Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Prescription Deleted')", true);
                    conn.Close();
                    ShowPrescriptions();
                }
                catch (Exception Ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Prescription Delete Unsuccessfully')", true);
                }

            }
        }

        int Key = 0;
        protected void PrescriptionGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PatientDDL.DataTextField = PrescriptionGV.SelectedRow.Cells[2].Text;
                TreatmentDDL.DataTextField = PrescriptionGV.SelectedRow.Cells[3].Text;
                TreatCost.Value = PrescriptionGV.SelectedRow.Cells[4].Text;
                Medicines.Value = PrescriptionGV.SelectedRow.Cells[5].Text;
                MedQty.Value = PrescriptionGV.SelectedRow.Cells[6].Text;
                if (TreatCost.Value == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = Convert.ToInt32(PrescriptionGV.SelectedRow.Cells[1].Text);
                }
            }catch (Exception)
            {
                throw;
            }

        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            InsertPrescription();
        }

        protected void PrescEditBtn_Click(object sender, EventArgs e)
        {
            EditPrescription();
        }

        protected void PrescDeleteBtn_Click(object sender, EventArgs e)
        {
            DeletePrescription();
        }
    }
}