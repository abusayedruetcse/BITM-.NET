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
        //string connectionString = @"Server=PC-301-17\SQLEXPRESS ; Database=StockManagementDB  ;Integrated Security=True  ";
        string connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS;Database=StockManagementDB;Integrated Security=True";
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;

        public CategoryRepository()
        {
            sqlConnection = new SqlConnection(connectionString);
        }
        public int Update(Category category)
        {
            int isExecuted = 0;
            try
            {
                //2
                sqlCommand = new SqlCommand();
                commandString = "UPDATE Categories SET Name =  '" + category.Name + "' WHERE ID = " + category.ID + "";
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
        public int Insert(Category category)
        {
            int isExecuted = 0;
            try
            {
                commandString = @"INSERT INTO Categories (Name) VALUES('" + category.Name + "')";
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
