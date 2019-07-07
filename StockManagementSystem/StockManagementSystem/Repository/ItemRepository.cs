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
    public class ItemRepository
    {
        string connectionString;
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
       
        public ItemRepository()
        {
            //connectionString = @"Server=PC-301-17\SQLEXPRESS ; Database=StockManagementDB  ;Integrated Security=True  ";
            //connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS;Database=StockManagementDB ;Integrated Security=True";
            connectionString = @"Server=" + SMSDBScript.ServerName + ";Database=" + SMSDBScript.DatabaseName + ";Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            
        }
        public int Insert(Item item,History history)
        {
            int isExecuted = 0;
            try
            {
                commandString = @"INSERT INTO Items VALUES('" + item.Name + "'," + item.CategoryID + " ," + item.CompanyID + "," + item.ReorderLevel + ", 0 )" + "INSERT INTO InsertUpdateHistory VALUES(" + history.UserID + ",'" + history.TableName + "'," + history.TableRowNo + " ,'" + history.Element + "','" + history.DateAndTime + "')";
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
        public bool IsDuplicate(Item item)
        {
            bool isDuplicate = false;
            try
            {
                commandString = @"SELECT ID FROM Items WHERE Name='" + item.Name + "' AND CategoryID =" + item.CategoryID + " AND CompanyID=" + item.CompanyID;
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable != null && dataTable.Rows.Count > 0)
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
        public DataTable ComboxBoxWithSelect(string tableName)
        {
            try
            {
                commandString = @"SELECT * FROM " + tableName;
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = commandString;
                sqlCommand.Connection = sqlConnection;

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
        public int NoOfItem()
        {
            commandString = @"SELECT * FROM Items";
            sqlCommand = new SqlCommand();
            sqlCommand.CommandText = commandString;
            sqlCommand.Connection = sqlConnection;

            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable.Rows.Count;
        }
    }
}
