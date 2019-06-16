using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinApp
{
    public partial class DatabaseConnection : Form
    {
        public DatabaseConnection()
        {
            InitializeComponent();
        }
        class Student
        {
            public string Name { set; get; }
            public string Address { set; get; }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Name = nameTextBox.Text;
            student.Address= addressTextBox.Text;
            Insert(student);
            
        }
        private void Insert(Student student)
        {
            try
            {
                //1
                SqlConnection sqlConnection = new SqlConnection();
                string connectionString = @"Server=PC-301-17\SQLEXPRESS ;Database=StudentDB ; Integrated Security=True ";
                sqlConnection.ConnectionString = connectionString;

                //2
                SqlCommand sqlCommand = new SqlCommand();
                //string commandString = @"INSERT INTO Students(RollNo,Name,Age,Address,DistrictID) VALUES('CSE001', 'ALI', 21, 'Mirpur', 1)";
                string commandString = @"INSERT INTO Students(RollNo,Name,Age,Address,DistrictID) VALUES('CSE001', '"+student.Name+"', 21, '"+student.Address+"', 1)";
                sqlCommand.CommandText = commandString;
                sqlCommand.Connection = sqlConnection;

                //3
                sqlConnection.Open();

                //4
                int isExecuted = 0;
                isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    MessageBox.Show("Saved Successfully");
                }
                else
                {
                    MessageBox.Show("Save Failed!");
                }

                //5
                sqlConnection.Close();
            }
            catch (Exception excetion)
            {
                MessageBox.Show(excetion.Message);
            }
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=PC-301-17\SQLEXPRESS ;Database=StudentDB ; Integrated Security=True ";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string commandString = @"SELECT * FROM Students";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            if(dataTable.Rows.Count>0)
            {
                displayDataGridView.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("No Student Info");
            }
            sqlConnection.Close();
        }
    }
}
