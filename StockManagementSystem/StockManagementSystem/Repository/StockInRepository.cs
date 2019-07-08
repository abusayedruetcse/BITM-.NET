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
            connectionString = @"Server=" + SMSDBScript.ServerName + ";Database=" + SMSDBScript.DatabaseName + ";Integrated Security=True";
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
        public DataTable LoadCategoryToComboBox(int companyID)
        {
            commandString = @"SELECT DISTINCT cat.Name AS Name,cat.ID AS ID FROM Categories AS cat , Items AS i WHERE i.CategoryID=cat.ID AND i.CompanyID="+companyID+"";
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
            commandString = @"UPDATE StockIns SET Quantity=" + stockIn.Quantity + "  WHERE ID=" + stockIn.ID + ""+ "INSERT INTO InsertUpdateHistory VALUES(" + history.UserID + ",'" + history.TableName + "'," + history.TableRowNo + " ,'" + history.Element + "','" + history.DateAndTime + "')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            isExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public int InsertStockIn(StockIn stockIn,History history)
        {
            int isExecuted = 0;
            commandString = @"INSERT INTO StockIns VALUES('" + stockIn.Date + "'," + stockIn.Quantity + "," + stockIn.ItemID + ")"+ "INSERT INTO InsertUpdateHistory VALUES(" + history.UserID + ",'" + history.TableName + "'," + history.TableRowNo + " ,'" + history.Element + "','" + history.DateAndTime + "')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            isExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return isExecuted;
        }
        public DataTable GetItemCompanyCategory(Item item)
        {
            commandString = @"SELECT i.Name AS ItemName, com.Name AS CompanyName, cat.Name AS CategoryName, AvailableQuantity, ReorderLevel FROM Items AS i, Companies AS com, Categories AS cat WHERE i.ID="+item.ID+" AND i.CompanyID=com.ID AND i.CategoryID=cat.ID";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }
        public DataTable DisplayRecords(StockIn stockIn)
        {
            commandString = @"SELECT s.ID AS ID,ItemID, Name AS ItemName,Date,Quantity FROM StockIns AS s LEFT OUTER JOIN Items AS i ON s.ItemID=i.ID WHERE s.ItemID="+stockIn.ItemID+" ORDER BY s.Date DESC";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }
        public int StockInRowCount()
        {
            commandString = @"SELECT * FROM StockIns";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable.Rows.Count;
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
