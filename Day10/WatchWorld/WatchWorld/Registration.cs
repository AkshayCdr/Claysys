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
using System.Xml.Linq;

namespace WatchWorld
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-10MH51F\\SQLEXPRESS;Initial Catalog=WatchWorld;Integrated Security=True");
        public int Id { get; set; }



        private void Registration_Load(object sender, EventArgs e)
        {
            GetLoginDetails();
        }

        private void GetLoginDetails()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Registration", conn);
            DataTable dt = new DataTable();

            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            dt.Load(dr);

            conn.Close();

            RegistrationDataGridView.DataSource = dt;

        }

        private void insert_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                string first_name, last_name,  phone, email, address, state, city, username, password;
                int age;
                char gender;
                DateTime date_of_birth;

                first_name = txtFirstName.Text;
                last_name = txtLastName.Text;
                date_of_birth = dateTimePicker.Value;
                email = txtEmail.Text;
                age = Convert.ToInt32(txtAge.Text);
                phone = txtPhone.Text;
                address = txtAddress.Text;
                state = txtState.Text;
                city = txtCity.Text;
                username = txtUsername.Text;
                password = txtPassword.Text;

                if(radioButtonMale.Checked)
                {
                    gender = 'M';
                }
                else
                {
                    gender = 'F';
                }

                

                SqlCommand cmd = new SqlCommand("INSERT INTO Registration (first_name,last_name,date_of_birth,age,gender,phone,email,address,state,city,username,password) VALUES (@first_name,@last_name,@date_of_birth,@age,@gender,@phone,@email,@address,@state,@city,@username,@password)", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@first_name", first_name);
                cmd.Parameters.AddWithValue("@last_name", last_name);
                cmd.Parameters.AddWithValue("@date_of_birth", date_of_birth);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@state", state);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("new User is loged in ", "saved");

                GetLoginDetails();

                Clear();

            }
        }

        private void Clear()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtAge.Clear();
            txtCity.Items.Clear();
            txtPassword.Clear();
            txtPhone.Clear();
            txtState.Items.Clear();
            txtUsername.Clear();
            radioButtonMale.Checked = false;
            radioButtonFemale.Checked = false;

        }

        private bool isValid()
        {
            if (txtEmail.Text == string.Empty)
            {
                MessageBox.Show("Email is required ", "failed");
                return false;
            }
            return true;

        }

        private void reset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void RegistrationDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = Convert.ToInt32(RegistrationDataGridView.SelectedRows[0].Cells[0].Value);
            txtFirstName.Text = RegistrationDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtLastName.Text = RegistrationDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            dateTimePicker.Text = RegistrationDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            txtAge.Text = RegistrationDataGridView.SelectedRows[0].Cells[4].Value.ToString();
            //txtAge.Text = RegistrationDataGridView.SelectedRows[0].Cells[5].Value.ToString();
            txtPhone.Text = RegistrationDataGridView.SelectedRows[0].Cells[6].Value.ToString();
            txtEmail.Text = RegistrationDataGridView.SelectedRows[0].Cells[7].Value.ToString();
            txtAddress.Text = RegistrationDataGridView.SelectedRows[0].Cells[8].Value.ToString();
            txtState.Text = RegistrationDataGridView.SelectedRows[0].Cells[9].Value.ToString();
            txtCity.Text = RegistrationDataGridView.SelectedRows[0].Cells[10].Value.ToString();
            txtUsername.Text = RegistrationDataGridView.SelectedRows[0].Cells[11].Value.ToString();
            txtPassword.Text = RegistrationDataGridView.SelectedRows[0].Cells[12].Value.ToString();
        }
    }
}
