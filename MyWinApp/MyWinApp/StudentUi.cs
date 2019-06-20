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
using MyWinApp.BLL;

namespace MyWinApp
{
    public partial class StudentUi : Form
    {
        string connectionString = @"Server=PC-301-17\SQLEXPRESS; Database=StudentDB; Integrated Security=True";
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        Student student;
        StudentManager _studentManager;
        public StudentUi()
        {
            InitializeComponent();          
            sqlConnection = new SqlConnection(connectionString);
            student = new Student();
        }

        private void StudentUi_Load(object sender, EventArgs e)
        {           
            _studentManager = new StudentManager();            
            districtComboBox.DataSource = _studentManager.LoadDistrict();
            districtComboBox.Text = "<Select District>";
        }
        
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(IsRollDuplicate(rollNoTextBox.Text))
            {
                messageLabel.Text = "Roll No is Duplicate,Enter Unique Roll No";
                return;
            }
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
            try
            {
                commandString = @"INSERT INTO Students(RollNo,Name,Age,Address,DistrictID) VALUES ('" + student.RollNo + "','" + student.Name + "'," + student.Age + ",'" + student.Address + "', " + student.DistrictID + ")";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                int isExecuted;
                isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    messageLabel.Text = "Student Information Saved";
                }
                else
                {
                    messageLabel.Text = "Save Failed!";
                }
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            displayDataGridView.DataSource=_studentManager.ShowStudents();
            foreach (DataGridViewRow row in displayDataGridView.Rows)
                   row.Cells["SL"].Value = (row.Index + 1).ToString();
        }
        
        private bool IsRollDuplicate(string roll)
        {
            bool isDuplicate = false;
            try
            {               
                commandString = @"SELECT * FROM Students WHERE RollNo ='" + roll + "'";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count> 0)
                {
                    isDuplicate = true;
                }
                sqlConnection.Close();              
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            return isDuplicate;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            student.RollNo = rollNoTextBox.Text;
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                messageLabel.Text = "Name Field is Empty!";
                return;
            }
            student.Name = nameTextBox.Text;
            if (String.IsNullOrEmpty(ageTextBox.Text))
            {
                messageLabel.Text = "Age Field is Empty!";
                return;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(ageTextBox.Text, "[^0-9]"))
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
            if (districtComboBox.Text.Equals("<Select District>"))
            {
                messageLabel.Text = "Select District";
                return;
            }
            student.DistrictID = Convert.ToInt32(districtComboBox.SelectedValue);
            UpdateStudent(student);
            messageLabel.Text = "Successfully Edited!";
            //Cleaning the text box
            rollNoTextBox.Text = "";
            nameTextBox.Text = "";
            ageTextBox.Text = "";
            addressTextBox.Text = "";
            districtComboBox.Text = "<Select District>";           
        }
        private void UpdateStudent(Student student)
        {
            try
            {
                commandString = @"UPDATE Students SET Name='" + student.Name + "', Age=" + student.Age + ", DistrictID= " + student.DistrictID + ",Address='" + student.Address + "' WHERE RollNo='" + student.RollNo + "'";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                displayDataGridView.DataSource = _studentManager.ShowStudents();
                foreach (DataGridViewRow row in displayDataGridView.Rows)
                    row.Cells["SL"].Value = (row.Index + 1).ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }
        private void displayDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
            
            
            try
            {        
                rollNoTextBox.Text = displayDataGridView.CurrentRow.Cells["RollNo"].FormattedValue.ToString();
                commandString = @"SELECT RollNo, s.Name, Age, Address, d.Name AS District FROM Students AS s LEFT JOIN Districts AS d ON s.DistrictId=d.ID WHERE RollNo='"+rollNoTextBox.Text+"' ";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if(dataTable.Rows.Count>0)
                {
                    DataRow row = dataTable.Rows[0];
                    nameTextBox.Text = row["Name"].ToString();
                    ageTextBox.Text = row["Age"].ToString();
                    districtComboBox.Text = row["District"].ToString();
                    addressTextBox.Text = row["Address"].ToString();
                }

                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            student.RollNo = rollNoTextBox.Text;
            DeleteStudent(student);
            messageLabel.Text = student.RollNo + " Student is deleted successfully";
            //Cleaning the text box
            rollNoTextBox.Text = "";
            nameTextBox.Text = "";
            ageTextBox.Text = "";
            addressTextBox.Text = "";
            districtComboBox.Text = "<Select District>";
        }
        private void DeleteStudent(Student student)
        {
            try
            {
                commandString = @"DELETE Students WHERE RollNo='"+student.RollNo+"'";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                displayDataGridView.DataSource = _studentManager.ShowStudents();
                foreach (DataGridViewRow row in displayDataGridView.Rows)
                    row.Cells["SL"].Value = (row.Index + 1).ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
