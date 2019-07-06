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
    public class SignUpRepository
    {
        string connectionString;
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        public SignUpRepository()
        {
            connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS ;Database=StockManagementDB ;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        public bool IsUserAccountCreated(UserAccount userAccount)
        {
            int isExecuted = 0;
            commandString = @"INSERT INTO UserAccount VALUES('"+userAccount.Email+"','"+userAccount.UserName+"','"+userAccount.Password+"')";
            sqlCommand = new SqlCommand(commandString,sqlConnection);
            sqlConnection.Open();
            isExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return isExecuted > 0;

        } 
        public bool IsPasswordUnique(UserAccount userAccount)
        {
            int isExecuted = 0;
            commandString = @"SELECT * FROM UserAccount WHERE Password='" + userAccount.Password + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            isExecuted = dataTable.Rows.Count;
            sqlConnection.Close();

            return isExecuted == 0;
        }

    }
}
