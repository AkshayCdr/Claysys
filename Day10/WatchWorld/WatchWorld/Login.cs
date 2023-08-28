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

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-10MH51F\\SQLEXPRESS;Initial Catalog = project1; Integrated Security = True");

        public int Id { get; set; }

        private void Login_Load(object sender, EventArgs e)
        {
            GetLoginDetails();
        }

        private void GetLoginDetails()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Log", conn);
            DataTable dt = new DataTable();

            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            dt.Load(dr);

            conn.Close();

            LoginDataGridView.DataSource = dt;

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

            if (isValid())
            {
                string email, password;

                email = txtEmail.Text;
                password = txtPassword.Text;

                SqlCommand cmd = new SqlCommand("INSERT INTO LOG (email,password) VALUES (@email,@password)", conn);

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

        private bool isValid()
        {
            if (txtEmail.Text == string.Empty)
            {
                MessageBox.Show("Email is required ", "failed");
                return false;
            }
            return true;
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                string email, password;

                email = txtEmail.Text;
                password = txtPassword.Text;
                SqlCommand cmd = new SqlCommand("UPDATE LOG SET @email = email,@password = password", conn);

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

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

        private void Delete_Click(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM LOG WHERE @Id = Id", conn);
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

        private void Reset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtEmail.Focus();
        }

        private void LoginDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = Convert.ToInt32(LoginDataGridView.SelectedRows[0].Cells[0].Value);
            txtEmail.Text = LoginDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtPassword.Text = LoginDataGridView.SelectedRows[0].Cells[2].Value.ToString();
        }

        
    }
}

