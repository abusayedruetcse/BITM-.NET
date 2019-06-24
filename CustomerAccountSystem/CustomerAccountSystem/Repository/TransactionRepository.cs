using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using CustomerAccountSystem.Models;

namespace CustomerAccountSystem.Repository
{
    public class TransactionRepository
    {
        string connectionString;
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;

        public TransactionRepository()
        {
            connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS; Database= CustomerInfoDB; Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        public DataTable GetAmount(Account account)
        {
            commandString = @"SELECT * FROM Accounts WHERE AccountNo= '"+account.AccountNo+"'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            
            sqlConnection.Close();
            return dataTable;
        }
        public int UpdateAccount(Account account)
        {
            int isExecuted = 0;
            commandString = @"UPDATE Accounts SET Amount=" + account.Amount + "  WHERE AccountNo='" + account.AccountNo + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            isExecuted=sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return isExecuted;
        }
    }
}
