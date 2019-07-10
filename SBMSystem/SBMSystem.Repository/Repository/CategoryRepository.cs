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
            connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS; Database=SBMSDB;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        public bool AddCategory(Category category)
        {
            int isExecuted = 0;
            commandString = @"INSERT INTO Categories VALUES('"+category.Code+"','"+category.Name+"')";
            sqlCommand = new SqlCommand(commandString,sqlConnection);
            sqlConnection.Open();
            isExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return isExecuted > 0;
        } 
        public bool UpdateCategory(Category category)
        {
            int isExecuted = 0;
            commandString = @"UPDATE Categories SET Name='"+category.Name+"' WHERE Code='"+category.Code+"'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            isExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return isExecuted > 0;
        }
        public bool DeleteCategory(Category category)
        {
            int isExecuted = 0;
            commandString = @"DELETE Categories WHERE Code='"+category.Code+"'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            isExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return isExecuted > 0;
        }
        public DataTable GetCategories()
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
    }
}
