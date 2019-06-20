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
        string connectionString = @"Server=PC-301-17\SQLEXPRESS; Database=StudentDB; Integrated Security=True";
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

        public void InsertStudent(Student student)
        {
            try
            {
                commandString = @"INSERT INTO Students(RollNo,Name,Age,Address,DistrictID) VALUES ('" + student.RollNo + "','" + student.Name + "'," + student.Age + ",'" + student.Address + "', " + student.DistrictID + ")";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                int isExecuted;
                isExecuted = sqlCommand.ExecuteNonQuery();                
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message);
            }
        }
    }
}
