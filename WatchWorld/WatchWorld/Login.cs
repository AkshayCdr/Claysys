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

namespace WatchWorld
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-10MH51F\\SQLEXPRESS;Initial Catalog =WatchWorld; Integrated Security = True");

        public int Id { get; set; }

        private void Login_Load(object sender, EventArgs e)
        {
            GetLoginDetails();
        }

        private void GetLoginDetails()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Login", conn);
            DataTable dt = new DataTable();

            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            dt.Load(dr);

            conn.Close();

            LoginDataGridView.DataSource = dt;

        }



        private bool isValid()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required.", "Validation Failed");
                return false;
            }
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Invalid email format.", "Validation Failed");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password is required.", "Validation Failed");
                return false;
            }
            if (txtPassword.Text.Length < 8)
            {
                MessageBox.Show("Password length should be at least 8 characters.", "Validation Failed");
                return false;
            }
            if (!HasAtLeastOneNumber(txtPassword.Text))
            {
                MessageBox.Show("Password should contain at least one number.", "Validation Failed");
                return false;
            }
            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool HasAtLeastOneNumber(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }




        private void Clear()
        {
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtEmail.Focus();
        }

      

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            if (isValid())
            {
                string email, password;

                email = txtEmail.Text;
                password = txtPassword.Text;

                SqlCommand cmd = new SqlCommand("INSERT INTO Login (email,password) VALUES (@email,@password)", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("new User is loged in ", "saved");

                GetLoginDetails();
                Clear();

            }
        }

        private void Update_Click_1(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                string email, password;

                email = txtEmail.Text;
                password = txtPassword.Text;
                SqlCommand cmd = new SqlCommand("UPDATE Login SET email = @email,password = @password WHERE Id = @Id", conn);

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@Id", Id);

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("use details updated", "updated");

                GetLoginDetails();
                Clear();

            }
            else
            {
                MessageBox.Show("Select record to update", "Select");
            }

        }

        private void Delete_Click_1(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Login WHERE Id = @Id", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", Id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Record is deleted ", "Deleted");
                GetLoginDetails();
                Clear();
            }
            else
            {
                MessageBox.Show("Select record", "Select");
            }
        }

        private void LoginDataGridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Id = Convert.ToInt32(LoginDataGridView.SelectedRows[0].Cells[0].Value);
            txtEmail.Text = LoginDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtPassword.Text = LoginDataGridView.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void Reset_Click_1(object sender, EventArgs e)
        {
            Clear();
        }

      
    }
}

