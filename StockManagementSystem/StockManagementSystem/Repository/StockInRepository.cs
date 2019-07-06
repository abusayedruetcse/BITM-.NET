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
        public DataTable LoadFilteredItemToComboBox(int categoryID,int companyID)
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
        public void UpdateItem(Item item)
        {
            int isExecuted = 0;
            commandString = @"UPDATE Items SET AvailableQuantity=" + item.AvailableQuantity + "  WHERE ID=" + item.ID + "";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            isExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void UpdateStockIn(StockIn stockIn,History history)
        {
            int isExecuted = 0;
            commandString = @"UPDATE StockIns SET Quantity=" + stockIn.Quantity + "  WHERE ID=" + stockIn.ID + ""+ "INSERT INTO InsertUpdateHistory VALUES(" + history.UserID + ",'" + history.TableName + "'," + history.TableRowNo + " ,'" + history.DateAndTime + "')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            isExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public int InsertStockIn(StockIn stockIn,History history)
        {
            int isExecuted = 0;
            commandString = @"INSERT INTO StockIns VALUES('" + stockIn.Date + "'," + stockIn.Quantity + "," + stockIn.ItemID + ")"+ "INSERT INTO InsertUpdateHistory VALUES(" + history.UserID + ",'" + history.TableName + "'," + history.TableRowNo + " ,'" + history.DateAndTime + "')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            isExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return isExecuted;
        }
        public DataTable GetItem(Item item)
        {
            commandString = @"SELECT * FROM Items WHERE ID=" + item.ID + "";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }
        public DataTable DisplayRecords()
        {
            commandString = @"SELECT s.ID AS ID,ItemID, Name AS ItemName,Date,Quantity FROM StockIns AS s LEFT OUTER JOIN Items AS i ON s.ItemID=i.ID ORDER BY s.Date DESC";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }
        public DataTable GetAvailableQuantityAndReorderLevel(int categoryID,int companyID,string itemName)
        {
            commandString = @"SELECT * FROM Items WHERE Name='" + itemName + "' AND CategoryID =" + categoryID + " AND CompanyID=" + companyID + "";
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
