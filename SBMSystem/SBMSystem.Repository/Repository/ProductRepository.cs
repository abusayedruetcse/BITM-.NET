using SBMSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSystem.Repository.Repository
{
    public class ProductRepository
    {
        string connectionString;
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        public ProductRepository()
        {
            connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS; Database=SBMSDB;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
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
        public bool AddProduct(Product product)
        {
            int isExecuted = 0;
            commandString = @"INSERT INTO Products VALUES('" + product.Code + "','" + product.Name + "','"+product.CategoryCode+"',"+product.ReorderLevel+" ,' "+product.ImageProduct+" ','"+product.Description+"')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            isExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return isExecuted > 0;
        } 
        public DataTable GetProducts()
        {
            commandString = @"SELECT * FROM Products";
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
