using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using StockManagementSystem.Models;

namespace StockManagementSystem.Repository
{
    public class CompanyRepository
    {
        string connectionString; 
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        public CompanyRepository()
        {
            //connectionString = @"Server=PC-301-17\SQLEXPRESS ; Database=StockManagementDB  ;Integrated Security=True  ";
            connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS ; Database=StockManagementDB;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }


        public DataTable Display()
        {
            try
            {
                commandString = @"SELECT * FROM Companies";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();

            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message);
            }          
            return dataTable;
        }
        public int Insert(Company company)
        {
            int isExecuted = 0;
            try
            {
                commandString = @"INSERT INTO Companies (Name) VALUES('" + company.Name + "')";
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = commandString;
                sqlCommand.Connection = sqlConnection;

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
        public int Update(Company company)
        {
            int isExecuted = 0;
            try
            {               
                SqlCommand sqlCommand = new SqlCommand();
                string commandString = "UPDATE Companies SET Name =  '" + company.Name + "' WHERE ID = " + company.ID + "";
                sqlCommand.CommandText = commandString;
                sqlCommand.Connection = sqlConnection;

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
    }
}
