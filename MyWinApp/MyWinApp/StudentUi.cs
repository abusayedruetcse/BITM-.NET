﻿using System;
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
        string connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS; Database=StudentDB; Integrated Security=True";
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
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
            //Display Records
            displayDataGridView.DataSource = _studentManager.ShowStudents();
            foreach (DataGridViewRow row in displayDataGridView.Rows)
                row.Cells["SL"].Value = (row.Index + 1).ToString();
            displayDataGridView.RowHeadersVisible = false;
        }
        
        private void SaveButton_Click(object sender, EventArgs e)
        {
            int isExecuted = 0;
            if (SaveButton.Text.Equals("Confirm"))
            {
                student.RollNo = rollNoTextBox.Text;
                isExecuted = _studentManager.DeleteStudent(student);
                if(isExecuted>0)
                {
                    messageLabel.Text = student.RollNo + " Student is deleted successfully";
                }
                else
                {
                    messageLabel.Text = student.RollNo + " Student Deletion is Failed!";
                }
                
            }
            else
            {
                if (SaveButton.Text.Equals("Save"))
                {
                    if (IsRollDuplicate(rollNoTextBox.Text))
                    {
                        messageLabel.Text = "Roll No is Duplicate,Enter Unique Roll No";
                        return;
                    }
                    if (String.IsNullOrEmpty(rollNoTextBox.Text))
                    {
                        messageLabel.Text = "RollNo Field is Empty!";
                        return;
                    }
                }
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
                
                if (SaveButton.Text.Equals("Save"))
                {
                    isExecuted = _studentManager.InsertStudent(student);
                }
                else
                {
                    isExecuted = _studentManager.UpdateStudent(student);
                }


                if (isExecuted > 0)
                {
                    messageLabel.Text = "Student Information " + SaveButton.Text + "d";
                }
                else
                {
                    messageLabel.Text = SaveButton.Text + " Failed!";
                }
            } 
            //Display data 
            displayDataGridView.DataSource = _studentManager.ShowStudents();
            foreach (DataGridViewRow row in displayDataGridView.Rows)
                row.Cells["SL"].Value = (row.Index + 1).ToString();
            displayDataGridView.RowHeadersVisible = false;

            //Cleaning the text box
            rollNoTextBox.Text = "";
            nameTextBox.Text = "";
            ageTextBox.Text = "";
            addressTextBox.Text = "";
            districtComboBox.Text = "<Select District>";
            SaveButton.Text = "Save";
        }
        

        private void ShowButton_Click(object sender, EventArgs e)
        {
            rollNoTextBox.Text = "";
            nameTextBox.Text = "";
            ageTextBox.Text = "";
            addressTextBox.Text = "";
            districtComboBox.Text = "<Select District>";
            SaveButton.Text = "Save";
            displayDataGridView.DataSource=_studentManager.ShowStudents();
            foreach (DataGridViewRow row in displayDataGridView.Rows)
                   row.Cells["SL"].Value = (row.Index + 1).ToString();
            displayDataGridView.RowHeadersVisible = false;
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
            rollNoTextBox.Text = displayDataGridView.CurrentRow.Cells["RollNoColumn"].FormattedValue.ToString();
            nameTextBox.Text = displayDataGridView.CurrentRow.Cells["NameColumn"].FormattedValue.ToString();
            ageTextBox.Text = displayDataGridView.CurrentRow.Cells["AgeColumn"].FormattedValue.ToString();
            districtComboBox.Text = displayDataGridView.CurrentRow.Cells["DistrictColumn"].FormattedValue.ToString();
            addressTextBox.Text = displayDataGridView.CurrentRow.Cells["AddressColumn"].FormattedValue.ToString();

            SaveButton.Text = "Update";                    
        }    
        
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            rollNoTextBox.Text = displayDataGridView.CurrentRow.Cells["RollNoColumn"].FormattedValue.ToString();
            nameTextBox.Text = displayDataGridView.CurrentRow.Cells["NameColumn"].FormattedValue.ToString();
            ageTextBox.Text = displayDataGridView.CurrentRow.Cells["AgeColumn"].FormattedValue.ToString();
            districtComboBox.Text = displayDataGridView.CurrentRow.Cells["DistrictColumn"].FormattedValue.ToString();
            addressTextBox.Text = displayDataGridView.CurrentRow.Cells["AddressColumn"].FormattedValue.ToString();

            SaveButton.Text = "Confirm";           
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            student.RollNo = rollNoTextBox.Text;
            student.Name = nameTextBox.Text;
            dataTable = _studentManager.SearchStudent(student);
            if (dataTable!=null && dataTable.Rows.Count>0)            
            {
                displayDataGridView.DataSource = dataTable;
            }
            else
            {
                messageLabel.Text = "Not Found the Student";
                displayDataGridView.DataSource = null;
            }
        }
        private void SearchStudent(Student student)
        {
            messageLabel.Text = "";
            commandString = "";
            if(!String.IsNullOrEmpty(student.RollNo))
            {
                commandString = "SELECT * FROM Students WHERE RollNo LIKE '%"+student.RollNo+"%'";
            }
            if (!String.IsNullOrEmpty(student.Name))
            {
                commandString = "SELECT * FROM Students WHERE Name LIKE '%" + student.Name + "%'";
            }
            if (!String.IsNullOrEmpty(student.RollNo)&& !String.IsNullOrEmpty(student.Name))
            {
                commandString = "SELECT * FROM Students WHERE RollNo LIKE '%" + student.RollNo + "%' AND Name LIKE '%"+student.Name+"%'";
            }

            if(!String.IsNullOrEmpty(commandString))
            {
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    displayDataGridView.DataSource = dataTable;
                }
                else
                {
                    messageLabel.Text = "Not Found the Student";
                    displayDataGridView.DataSource = null;
                }
                sqlConnection.Close();
            }else
            {
                messageLabel.Text = "Not Found the Student";
                displayDataGridView.DataSource = null;
            }
            
        }
    }
}
