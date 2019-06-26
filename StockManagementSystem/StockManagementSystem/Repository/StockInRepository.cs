using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Models;
using System.Data;
using System.Data.SqlClient;

namespace StockManagementSystem.Repository
{
    public class StockInRepository
    {
        string connectionString; 
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        public StockInRepository()
        {
            connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS ;Database=StockManagementDB;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        public DataTable LoadCompanyToComboBox()
        {
            commandString = @"SELECT * FROM Companies";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);                       
            sqlConnection.Close();
            return dataTable;
        }
        public DataTable LoadCategoryToComboBox()
        {
            commandString = @"SELECT * FROM Categories";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }



    }
}
