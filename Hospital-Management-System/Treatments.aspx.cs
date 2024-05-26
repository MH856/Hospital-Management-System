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
    public partial class Treatments : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowTreatment();
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-793HLGI;Initial Catalog=HospitalDb;User ID=mh;Password=12345678");
        private void ShowTreatment()
        {
            conn.Open();
            string Query = "select * from Treatment";
            SqlDataAdapter Sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(Sda);
            var dataSet = new DataSet();
            Sda.Fill(dataSet);
            TreatmentGV.DataSource = dataSet.Tables[0];
            TreatmentGV.DataBind();
            conn.Close();
        }
        private void InsertTreatment()
        {
            if (TreatName.Value == "" || TreatCost.Value == "" || TreatDesc.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Missing Data')", true);
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into Treatment values(@TN,@TC,@TD)", conn);
                    cmd.Parameters.AddWithValue("@TN", TreatName.Value);
                    cmd.Parameters.AddWithValue("@TC", TreatCost.Value);
                    cmd.Parameters.AddWithValue("@TD", TreatDesc.Value);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Treatment Inserted')", true);
                    conn.Close();
                    ShowTreatment();
                }
                catch (Exception Ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Treatment Insert Unsuccessfully')", true);
                }

            }
        }

        private void EditTreatment()
        {
            if (TreatName.Value == "" || TreatCost.Value == "" || TreatDesc.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Missing Data')", true);
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Update Treatment set TreatName=@TN,TreatCost=@TC,TreatDesc=@TD where TreatID = @TKey", conn);
                    cmd.Parameters.AddWithValue("@TN", TreatName.Value);
                    cmd.Parameters.AddWithValue("@TC", TreatCost.Value);
                    cmd.Parameters.AddWithValue("@TD", TreatDesc.Value);
                    cmd.Parameters.AddWithValue("@TKey", TreatmentGV.SelectedRow.Cells[1].Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Treatment Updated')", true);
                    conn.Close();
                    ShowTreatment();
                }
                catch (Exception Ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Treatment Update Unsuccessfully')", true);
                }

            }
        }

        private void DeleteTreatment()
        {
            if (TreatName.Value == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Select Treatment to Delete')", true);
            }
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from Treatment where TreatID=@TKey", conn);
                    cmd.Parameters.AddWithValue("@TKey", TreatmentGV.SelectedRow.Cells[1].Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Treatment Deleted')", true);
                    conn.Close();
                    ShowTreatment();
                }
                catch (Exception Ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Treatment Delete Unsuccessfully')", true);
                }

            }
        }

        int Key = 0;
        protected void TreatmentGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            TreatName.Value = TreatmentGV.SelectedRow.Cells[2].Text;
            TreatCost.Value = TreatmentGV.SelectedRow.Cells[3].Text;
            TreatDesc.Value = TreatmentGV.SelectedRow.Cells[4].Text;

            if (TreatName.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(TreatmentGV.SelectedRow.Cells[1].Text);
            }
        }

        protected void EditBtnn_Click(object sender, EventArgs e)
        {
            EditTreatment();
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            InsertTreatment();
         }

        protected void DeleteBtnn_Click(object sender, EventArgs e)
        {
            DeleteTreatment();
        }
    }
}