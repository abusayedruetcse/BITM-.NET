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
        public bool IsUserValid()
        {
            int isExecuted = 0;
            commandString = @"SELECT * FROM UserAccount WHERE Password='"+UserAccount.Password+"' AND (Email= '"+UserAccount.Email+"' OR UserName='"+UserAccount.UserName+"')";
            sqlCommand = new SqlCommand(commandString,sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            isExecuted = dataTable.Rows.Count;
            if(isExecuted>0)
            {
                UserAccount.ID = Convert.ToInt32(dataTable.Rows[0]["ID"]);
            }
            sqlConnection.Close();
            return isExecuted > 0;
        }
            

    }
}
