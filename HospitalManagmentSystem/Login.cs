using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagmentSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            String username = UserNameField.Text;
            String password = PasswordField.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=DESKTOP-OS9RS86\\SQLEXPRESS;database=Hospital;integrated security=True";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM login WHERE username=@username AND password=@password";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
               
                this.Hide();
                Dashbord DS = new Dashbord();
                DS.Show();
            }
            else
            {
                
                MessageBox.Show("Username OR Password incorrect !!");
            }

            reader.Close();
            con.Close();
        }
    }
}
