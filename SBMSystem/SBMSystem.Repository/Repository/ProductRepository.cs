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
            connectionString = @"Server=PC-301-17\SQLEXPRESS; Database=SBMSDB;Integrated Security=True";
            //connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS; Database=SBMSDB;Integrated Security=True";
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
            commandString = @"SELECT p.Code AS Code,p.Name AS Name, c.Name AS Category, ReorderLevel,ImageProduct, Description FROM Products AS p LEFT JOIN Categories AS c ON p.CategoryCode=c.Code";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }
        public bool UpdateProduct(Product product)
        {
            int isExecuted = 0;
            commandString = @"UPDATE Products SET Name='"+product.Name+"',CategoryCode='"+product.CategoryCode+"',ReorderLevel='"+product.ReorderLevel+"',ImageProduct='"+product.ImageProduct+"',Description='"+product.Description+"' WHERE Code='"+product.Code+"'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            isExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return isExecuted > 0;
        }
        public bool DeleteProduct(Product product)
        {
            int isExecuted = 0;
            commandString = @"DELETE Products WHERE Code='" + product.Code + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            isExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return isExecuted > 0;
        }

    }
}
