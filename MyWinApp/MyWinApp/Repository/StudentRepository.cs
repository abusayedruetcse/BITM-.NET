using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using MyWinApp.Models;

namespace MyWinApp.Repository
{
    public class StudentRepository
    {
        string connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS; Database=StudentDB; Integrated Security=True";
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        public DataTable LoadDistrict()
        {          
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                commandString = @"SELECT * FROM Districts";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                dataTable = new DataTable();               
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    //districtComboBox.DataSource = dataTable;
                }

                sqlConnection.Close();               

            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message);
            }
            return dataTable;
        }

        public DataTable ShowStudents()
        {
            try
            {
                commandString = @"SELECT s.ID, RollNo, s.Name, Age, Address, DistrictID, d.Name AS District FROM Students AS s LEFT JOIN Districts AS d ON s.DistrictID=d.ID";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    //displayDataGridView.DataSource = dataTable;
                }
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message);
            }
            //foreach (DataGridViewRow row in displayDataGridView.Rows)
            //    row.Cells["SL"].Value = (row.Index + 1).ToString();

            return dataTable;
        }

        public int InsertStudent(Student student)
        {
            int isExecuted =0;
            try
            {
                commandString = @"INSERT INTO Students(RollNo,Name,Age,Address,DistrictID) VALUES ('" + student.RollNo + "','" + student.Name + "'," + student.Age + ",'" + student.Address + "', " + student.DistrictID + ")";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                
                isExecuted = sqlCommand.ExecuteNonQuery();                
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message);
            }
            return isExecuted;
        }
        public int UpdateStudent(Student student)
        {
            int isExecuted = 0;
            try
            {
                commandString = @"UPDATE Students SET Name='" + student.Name + "', Age=" + student.Age + ", DistrictID= " + student.DistrictID + ",Address='" + student.Address + "' WHERE RollNo='" + student.RollNo + "'";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                isExecuted = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();                
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message);
            }
            return isExecuted;
        }
        public int DeleteStudent(Student student)
        {
            int isExecuted = 0;
            try
            {
                commandString = @"DELETE Students WHERE RollNo='" + student.RollNo + "'";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();               
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message);
            }
            return isExecuted;
        }
        public DataTable SearchStudent(Student student)
        {            
            commandString = "";
            if (!String.IsNullOrEmpty(student.RollNo))
            {
                commandString = "SELECT * FROM Students WHERE RollNo LIKE '%" + student.RollNo + "%'";
            }
            if (!String.IsNullOrEmpty(student.Name))
            {
                commandString = "SELECT * FROM Students WHERE Name LIKE '%" + student.Name + "%'";
            }
            if (!String.IsNullOrEmpty(student.RollNo) && !String.IsNullOrEmpty(student.Name))
            {
                commandString = "SELECT * FROM Students WHERE RollNo LIKE '%" + student.RollNo + "%' AND Name LIKE '%" + student.Name + "%'";
            }

            if (!String.IsNullOrEmpty(commandString))
            {
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                             
                sqlConnection.Close();
                return dataTable;
            }
            else
            {
                return null;
            }

        }
        public bool IsRollDuplicate(string roll)
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

                if (dataTable.Rows.Count > 0)
                {
                    isDuplicate = true;
                }
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message);
            }
            return isDuplicate;
        }
    }
}
