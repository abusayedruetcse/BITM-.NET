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
    public class SearchRepository
    {
        string connectionString;
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        public SearchRepository()
        {
            //connectionString = @"Server=PC-301-17\SQLEXPRESS ; Database=StockManagementDB  ;Integrated Security=True  ";
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
        public DataTable LoadFilteredItemToDataGridView(int categoryID, int companyID,bool isCompanyLoaded,bool isCategoryLoaded)
        {
            if(isCategoryLoaded&&isCompanyLoaded)
            {
                commandString = @"SELECT i.Name AS Name,com.Name AS Company,cat.Name AS Category,AvailableQuantity,ReorderLevel FROM Items AS i, Categories AS cat, Companies AS com WHERE CategoryID=cat.ID AND CompanyID=com.ID AND CategoryID="+categoryID+" AND CompanyID="+companyID+"";
            }else if(isCategoryLoaded)
            {
                commandString = @"SELECT i.Name AS Name,com.Name AS Company,cat.Name AS Category,AvailableQuantity,ReorderLevel FROM Items AS i, Categories AS cat, Companies AS com WHERE CategoryID=cat.ID AND CompanyID=com.ID AND CategoryID=" + categoryID + "";
            }
            else
            {
                commandString = @"SELECT i.Name AS Name,com.Name AS Company,cat.Name AS Category,AvailableQuantity,ReorderLevel FROM Items AS i, Categories AS cat, Companies AS com WHERE CategoryID=cat.ID AND CompanyID=com.ID AND CompanyID=" + companyID + "";
            }

            //commandString = @"SELECT * FROM Items WHERE CategoryID =" + categoryID + " AND CompanyID=" + companyID + "";
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
