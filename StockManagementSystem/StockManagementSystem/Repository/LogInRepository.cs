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
    public class LogInRepository
    {
        string connectionString;
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        public LogInRepository()
        {
            connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS ;Database=StockManagementDB ;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        public bool IsUserValid(UserAccount userAccount)
        {
            int isExecuted = 0;
            commandString = @"SELECT * FROM UserAccount WHERE Password='"+userAccount.Password+"' AND (Email= '"+userAccount.Email+"' OR UserName='"+userAccount.UserName+"')";
            sqlCommand = new SqlCommand(commandString,sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            isExecuted = dataTable.Rows.Count;
            sqlConnection.Close();
            return isExecuted > 0;
        }
            

    }
}
