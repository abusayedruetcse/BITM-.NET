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
    public class StockOutRepository
    {
        string connectionString;
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        public StockOutRepository()
        {
            connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS ; Database=StockManagementDB  ;Integrated Security=True  ";
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
        public DataTable LoadFilteredCompanyToComboBox(int categoryID)
        {
            commandString = @"SELECT DISTINCT com.Name AS Name, i.CompanyID AS ID FROM Companies AS com LEFT JOIN Items AS i ON com.ID=i.CompanyID WHERE i.CategoryID="+categoryID+"";
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
        public DataTable LoadFilteredCategoryToComboBox(int companyID)
        {
            commandString = @"SELECT DISTINCT cat.Name, i.CategoryID FROM Categories AS cat LEFT JOIN Items AS i ON cat.ID=i.CategoryID WHERE i.CompanyID=" + companyID + "";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }
        public DataTable LoadFilteredItemToComboBox(int categoryID, int companyID)
        {
            commandString = @"SELECT * FROM Items WHERE CategoryID =" + categoryID + " AND CompanyID=" + companyID + "";
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
