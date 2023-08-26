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

namespace CRUD_operations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-10MH51F\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True");
        public int studentId;

        private void Form1_Load(object sender, EventArgs e)
        {
            GetStudentsRecord();
        }

        private void GetStudentsRecord()
        {
            SqlCommand cmd = new SqlCommand("Select * from StudentsTb",conn);
            DataTable dt = new DataTable();

            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            dt.Load(dr);

            conn.Close();

            StudentRecordDataGridView.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(isValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO StudentsTb (Name, FatherName,  Address, Mobile) VALUES (@name,@fatherName,@address,@mobile)", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name",txtStudentName.Text);
                cmd.Parameters.AddWithValue("@fatherName",txtFatherName.Text);
                //cmd.Parameters.AddWithValue("@rollNumber",txtRollNo.Text);
                cmd.Parameters.AddWithValue("@address",txtAddress.Text);
                cmd.Parameters.AddWithValue("@mobile",txtMobile.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close() ;

                MessageBox.Show("News student is succesfully saved in the database","saved",MessageBoxButtons.OK,MessageBoxIcon.Information);


                GetStudentsRecord();

                ResetFormControls();



            }
        }

        public bool isValid()
        {
            if(txtStudentName.Text == string.Empty)
            {
                MessageBox.Show("Student name is required","failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetFormControls();

        }

        private void ResetFormControls()
        {
            txtStudentName.Clear();
            txtFatherName.Clear();
            txtAddress.Clear();
            txtMobile.Clear();
        }

        private void StudentRecordDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            studentId = Convert.ToInt32(StudentRecordDataGridView.SelectedRows[0].Cells[0].Value);
            txtStudentName.Text = StudentRecordDataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtFatherName.Text = StudentRecordDataGridView.SelectedRows[0].Cells[2].Value.ToString();
            txtAddress.Text = StudentRecordDataGridView.SelectedRows[0].Cells[3].Value.ToString();
            txtMobile.Text = StudentRecordDataGridView.SelectedRows[0].Cells[4].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(studentId > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE  StudentsTb SET Name = @name, FatherName = @fatherName,  Address = @address, Mobile =@mobile WHERE StudentId = @Id", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", txtStudentName.Text);
                cmd.Parameters.AddWithValue("@fatherName", txtFatherName.Text);
                //cmd.Parameters.AddWithValue("@rollNumber",txtRollNo.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@mobile", txtMobile.Text);
                cmd.Parameters.AddWithValue("@Id", this.studentId);


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Student info updated sucessfully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);


                GetStudentsRecord();

                ResetFormControls();

            }
            else
            {
                MessageBox.Show("Please select ", "Select ?", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(studentId >0)
            {
                {
                    SqlCommand cmd = new SqlCommand("Delete from  StudentsTb WHERE StudentId = @Id", conn);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Id", this.studentId);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Student is deleted ", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    GetStudentsRecord();

                    ResetFormControls();

                }
            }
            else
            {
                MessageBox.Show("Please select ", "Select ?", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
