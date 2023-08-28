using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WatchWorld
{
    public partial class ContactUs : Form
    {
        public ContactUs()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-10MH51F\\SQLEXPRESS;Initial Catalog=WatchWorld;Integrated Security=True");
        public int Id { get; set; }

        private void ContactUs_Load(object sender, EventArgs e)
        {
            GetLoginDetails();
        }

        private void GetLoginDetails()
        {
            
                SqlCommand cmd = new SqlCommand("SELECT * FROM ContactUs", conn);
                DataTable dt = new DataTable();

                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                dt.Load(dr);

                conn.Close();

                ContactDataGridView.DataSource = dt;

           
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                string name, email,message;

                name = txtName.Text;
                email = txtEmail.Text;
                message = txtMessage.Text;

                SqlCommand cmd = new SqlCommand("INSERT INTO ContactUS (name,email,message) VALUES (@name,@email,@message)", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@message", message);

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
            txtName.Text =  string.Empty;
            txtEmail.Text = string.Empty;
            txtMessage.Text = string.Empty;
            txtEmail.Focus();

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
            if(Id> 0)
            {
                string name, email, message;

                name = txtName.Text;
                email = txtEmail.Text;
                message = txtMessage.Text;


                SqlCommand cmd = new SqlCommand("UPDATE ContactUS SET name = @name, email = @email, message = @message WHERE Id = @Id", conn);


                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@message", message);
                cmd.Parameters.AddWithValue("@Id", this.Id);

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("User details updated ", "Updated");

                GetLoginDetails();

                Clear();
            }
            else
            {
                MessageBox.Show("Select a record to update ", "Select?");

            }
        }

        private void ContactDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = Convert.ToInt32(ContactDataGridView.SelectedRows[0].Cells[0].Value);
            txtName.Text = ContactDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtEmail.Text = ContactDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            txtMessage.Text = ContactDataGridView.SelectedRows[0].Cells[3].Value.ToString();
             
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if(Id>0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM ContactUs WHERE Id = @Id", conn);

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", this.Id);

                conn.Open();

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("User Deleted ", "Deleted");

                GetLoginDetails();

                Clear();
            }
            else
            {
                MessageBox.Show("Select a record to delete ", "Select?");

            }
        }
    }
}
