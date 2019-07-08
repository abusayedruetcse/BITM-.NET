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
    public class CategoryRepository
    {
        string connectionString;
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;

        public CategoryRepository()
        {
            connectionString = @"Server="+SMSDBScript.ServerName+";Database="+SMSDBScript.DatabaseName+";Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        public DataTable IsUpdateCategoryDuplicate(Category category)
        {
            commandString = @"SELECT * FROM Categories WHERE Name='" + category.Name + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter();

            sqlDataAdapter.SelectCommand = sqlCommand;
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();
            return dataTable;
        }
        public bool IsCategoryDuplicate(Category category)
        {            
            commandString = @"SELECT * FROM Categories WHERE Name='"+category.Name+"'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter();

            sqlDataAdapter.SelectCommand = sqlCommand;
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConnection.Close();
            return dataTable.Rows.Count > 0;
        }
        public int Update(Category category,History history)
        {
            int isExecuted = 0;          
            try
            {
                //2
                sqlCommand = new SqlCommand();
                commandString = "UPDATE Categories SET Name =  '" + category.Name + "' WHERE ID = " + category.ID + "" + "INSERT INTO InsertUpdateHistory VALUES(" + history.UserID + ",'" + history.TableName + "'," + history.TableRowNo + " ,'" + history.Element + "' ,'" + history.DateAndTime + "')";
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
        public DataTable Display()
        {
            try
            {

                commandString = @"SELECT * FROM Categories";
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
        public int Insert(Category category,History history)
        {
            int isExecuted = 0;
            try
            {
                commandString = @"INSERT INTO Categories (Name) VALUES('" + category.Name + "')"+ "INSERT INTO InsertUpdateHistory VALUES("+history.UserID+",'"+history.TableName+"',"+history.TableRowNo+ " ,'" + history.Element + "' ,'" + history.DateAndTime+"')";
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
    }
}
