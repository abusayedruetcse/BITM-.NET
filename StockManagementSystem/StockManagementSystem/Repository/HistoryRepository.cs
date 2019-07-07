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
    public class HistoryRepository
    {
        string connectionString;
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable; 
        public HistoryRepository()
        {
            connectionString = @"Server=" + SMSDBScript.ServerName + ";Database=" + SMSDBScript.DatabaseName + ";Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        public DataTable LoadCategoryCompanyItemHistory(string tableName)
        {
            commandString = @"SELECT i.TableRowNo AS TableRowNo,i.Element AS Element,u.Email AS Email,i.DateAndTime AS DateAndTime FROM InsertUpdateHistory AS i, UserAccount AS u WHERE i.TableName='"+tableName+"' AND i.UserID=u.ID ORDER BY i.DateAndTime DESC";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        } 
        public DataTable LoadStockInOutHistory(string tableName)
        {
            commandString = @"SELECT i.TableRowNo AS TableRowNo,item.Name AS Element,u.Email AS Email,i.DateAndTime AS DateAndTime FROM InsertUpdateHistory AS i, UserAccount AS u, "+tableName+" AS t,Items AS item WHERE i.TableName='"+tableName+"' AND t.ID=i.TableRowNo AND t.ItemID=item.ID AND i.UserID=u.ID ORDER BY i.DateAndTime DESC";
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
