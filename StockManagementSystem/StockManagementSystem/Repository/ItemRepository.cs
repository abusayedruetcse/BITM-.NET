using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Models;
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
            connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS;Database=StockManagementDB ;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            
        }
        public int Insert(Item item)
        {
            int isExecuted = 0;
            try
            {
                //1
                commandString = @"INSERT INTO Items VALUES('" + item.Name + "'," + item.CategoryID + " ," + item.CompanyID + "," + item.ReorderLevel + ", 0 )";
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = commandString;
                sqlCommand.Connection = sqlConnection;

                //3
                sqlConnection.Open();

                //4
                
                isExecuted = sqlCommand.ExecuteNonQuery();
                //if (isExecuted > 0)
                //{
                //    messageLabel.Text = "Saved Successfully";
                //}
                //else
                //{
                //    messageLabel.Text = "Save Failed!";
                //}
                //5
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
