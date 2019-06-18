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
using MyWinApp.Models;

namespace MyWinApp
{
    public partial class StudentUi : Form
    {
        string connectionString = @"Server=PC-301-17\SQLEXPRESS; Database=StudentDB; Integrated Security=True";
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        Student student;

        public StudentUi()
        {
            InitializeComponent();          
            sqlConnection = new SqlConnection(connectionString);
            student = new Student();
        }

        private void StudentUi_Load(object sender, EventArgs e)
        {
            LoadDistrict();
        }
        private void LoadDistrict()
        {
            commandString = @"SELECT * FROM Districts";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            if(dataTable.Rows.Count>0)
            {
                districtComboBox.DataSource = dataTable;
            }

            sqlConnection.Close();

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            student.RollNo = rollNoTextBox.Text;
            student.Name = nameTextBox.Text;
            student.Age = Convert.ToInt32(ageTextBox.Text);
            student.Address = addressTextBox.Text;
            student.DistrictID = Convert.ToInt32(districtComboBox.SelectedValue);
            InsertStudent(student);
        }
        private void InsertStudent(Student student)
        {
            commandString = @"INSERT INTO Students(RollNo,Name,Age,Address,DistrictID) VALUES ('" + student.RollNo + "','" + student.Name + "'," + student.Age + ",'" + student.Address + "', " + student.DistrictID + ")";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            int isExecuted;
            isExecuted = sqlCommand.ExecuteNonQuery();
            if (isExecuted > 0)
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Save Failed!");
            }
            sqlConnection.Close();

        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            commandString = @"SELECT s.ID, RollNo, s.Name, Age, Address, DistrictID, d.Name AS District FROM Students AS s LEFT JOIN Districts AS d ON s.DistrictID=d.ID";
            sqlCommand = new SqlCommand(commandString,sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            if(dataTable.Rows.Count>0)
            {
                displayDataGridView.DataSource = dataTable;
            }           
            sqlConnection.Close();
        }
    }
}
