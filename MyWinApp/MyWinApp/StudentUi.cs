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
        string connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS; Database=StudentDB; Integrated Security=True";
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
            districtComboBox.Text = "<Select District>";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(rollNoTextBox.Text))
            {
                messageLabel.Text = "RollNo Field is Empty!";
                return;
            }
            student.RollNo = rollNoTextBox.Text;
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                messageLabel.Text = "Name Field is Empty!";
                return;
            }
            student.Name = nameTextBox.Text;
            if(String.IsNullOrEmpty(ageTextBox.Text))
            {
                messageLabel.Text = "Age Field is Empty!";
                return;
            }
            if(System.Text.RegularExpressions.Regex.IsMatch(ageTextBox.Text,"[^0-9]"))
            {
                messageLabel.Text = "Enter Numeric Value for Age";
                return;
            }
            student.Age = Convert.ToInt32(ageTextBox.Text);
            if (String.IsNullOrEmpty(addressTextBox.Text))
            {
                messageLabel.Text = "Address Field is Empty!";
                return;
            }
            student.Address = addressTextBox.Text;
            if(districtComboBox.Text.Equals("<Select District>"))
            {
                messageLabel.Text = "Select District";
                return;
            }
            student.DistrictID = Convert.ToInt32(districtComboBox.SelectedValue);
            InsertStudent(student);
            //Cleaning the text box
            rollNoTextBox.Text = "";
            nameTextBox.Text = "";
            ageTextBox.Text = "";
            addressTextBox.Text = "";
            districtComboBox.Text = "<Select District>";

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
            commandString = @"SELECT * FROM StudensView";
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
