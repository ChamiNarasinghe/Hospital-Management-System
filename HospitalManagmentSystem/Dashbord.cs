using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HospitalManagmentSystem
{
    public partial class Dashbord : Form
    {
        public Dashbord()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void buttonHospitalInformation_Click(object sender, EventArgs e)
        {
            buttonHospitalInformation.ForeColor = System.Drawing.Color.Red;
            buttonFullyHistoryofthePatient.ForeColor = System.Drawing.Color.Black;
            buttonAddDiagnosisInformation.ForeColor = System.Drawing.Color.Black;
            buttonAddNewPatientRecord.ForeColor = System.Drawing.Color.Black;

            panelHistoryOfPatient.Visible = false;
            panelAddDiagnosisInfo.Visible = false;
            panelHospitalInfo.Visible = true;
            AddPatientPanel.Visible = false;
            

        }

        private void buttonFullyHistoryofthePatient_Click(object sender, EventArgs e)
        {
            buttonHospitalInformation.ForeColor = System.Drawing.Color.Black;
            buttonFullyHistoryofthePatient.ForeColor = System.Drawing.Color.Red;
            buttonAddDiagnosisInformation.ForeColor = System.Drawing.Color.Black;
            buttonAddNewPatientRecord.ForeColor = System.Drawing.Color.Black;

            panelHistoryOfPatient.Visible = true;
            panelAddDiagnosisInfo.Visible = false;
            panelHospitalInfo.Visible = false;
            AddPatientPanel.Visible = false;


            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source= DESKTOP-OS9RS86\\SQLEXPRESS;database=Hospital;integrated security=True";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from AddPatient inner join PatientMore on AddPatient.pid =PatientMore.pid ";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView2.DataSource = DS.Tables[0];


        }

        private void buttonAddDiagnosisInformation_Click(object sender, EventArgs e)
        {
            buttonHospitalInformation.ForeColor = System.Drawing.Color.Black;
            buttonFullyHistoryofthePatient.ForeColor = System.Drawing.Color.Black;
            buttonAddDiagnosisInformation.ForeColor = System.Drawing.Color.Red;
            buttonAddNewPatientRecord.ForeColor = System.Drawing.Color.Black;

            panelAddDiagnosisInfo.Visible = true;
            panelHistoryOfPatient.Visible = false;
            panelHospitalInfo.Visible = false;
            AddPatientPanel.Visible = false;
        }

        private void buttonAddNewPatientRecord_Click(object sender, EventArgs e)
        {
            buttonHospitalInformation.ForeColor = System.Drawing.Color.Black;
            buttonFullyHistoryofthePatient.ForeColor = System.Drawing.Color.Black;
            buttonAddDiagnosisInformation.ForeColor = System.Drawing.Color.Black;
            buttonAddNewPatientRecord.ForeColor = System.Drawing.Color.Red;

            AddPatientPanel.Visible = true;
            panelAddDiagnosisInfo.Visible = false;
            panelHistoryOfPatient.Visible = false;
            panelHospitalInfo.Visible = false;
        }

        private void Dashbord_Load(object sender, EventArgs e)
        {
            AddPatientPanel.Visible = false;
            panelAddDiagnosisInfo.Visible = false;
            panelHistoryOfPatient.Visible = false;
            panelHospitalInfo.Visible = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                String name = textBoxName.Text;
                String address = textBoxAddress.Text;
                Int64 contact = Convert.ToInt64(textBoxContact.Text);
                int age = Convert.ToInt32(textBoxAge.Text);
                String gender = comboBoxGender.Text;
                String blood_group = textBoxBloodGroup.Text;
                String any = textBoxMajorDiseases.Text;
                int pid = Convert.ToInt32(textBoxPatientId.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= DESKTOP-OS9RS86\\SQLEXPRESS;database=Hospital;integrated security=True";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "insert into AddPatient (Name, Address, Contact, Age, Gender, Blood_Group, Major_Disease, pid) values (@name, @address, @contact, @age, @gender, @blood_group, @any, @pid)";

                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@blood_group", blood_group);
                cmd.Parameters.AddWithValue("@any", any);
                cmd.Parameters.AddWithValue("@pid", pid);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data inserted successfully!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            textBoxName.Clear();
            textBoxAddress.Clear();
            textBoxContact.Clear();
            textBoxAge.Clear();
            textBoxBloodGroup.Clear();
            comboBoxGender.ResetText();
            textBoxMajorDiseases.Clear();
            textBoxPatientId.Clear();
        }

        private void textBoxPID_TextChanged(object sender, EventArgs e)
        {
            if (textBoxPID.Text != "")
            {

                int pid = Convert.ToInt32(textBoxPID.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= DESKTOP-OS9RS86\\SQLEXPRESS;database=Hospital;integrated security=True";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from AddPatient where pid = " + pid + "";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                dataGridView1.DataSource=DS.Tables[0];

            }

        }

        private void buttonPatientInfoSave_Click(object sender, EventArgs e)
        {
            try
            {

                int pid = Convert.ToInt32(textBoxPID.Text);
                String sympt = textBoxSympoms.Text;
                String diag = textBoxDiagnosis.Text;
                String medicine = textBoxMedicines.Text;
                String ward = comboBoxWardRequired.Text;
                String ward_type = comboBoxTypeOfWard.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= DESKTOP-OS9RS86\\SQLEXPRESS;database=Hospital;integrated security=True";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "insert into PatientMore values ("+pid+",'"+sympt+"','"+diag+"','"+medicine+"','"+ward+"','"+ward_type+"')";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                
            }

            catch (Exception)
            {

                MessageBox.Show("Any Field is Empty 'OR' Data is in Wrong Format.");
            }

            MessageBox.Show("Data Saved.");

            textBoxDiagnosis.Clear();
            textBoxSympoms.Clear();
            textBoxPID.Clear();
            textBoxMedicines.Clear();
            comboBoxTypeOfWard.ResetText();
            comboBoxWardRequired.ResetText();
        }
       
    }
}
