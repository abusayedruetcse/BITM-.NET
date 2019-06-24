using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using CustomerAccountSystem.Models;

namespace CustomerAccountSystem.Repository
{
    public class EntryRepository
    {
        string connectionString;
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        public EntryRepository()
        {
            connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS; Database=CustomerInfoDB; Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        public int InsertEntry(Customer customer)
        {
            int isExecuted = 0;
            try
            {
                commandString = @"INSERT INTO Customers VALUES ('" + customer.AccountNo + "','" + customer.Name+ "','" + customer.Email + "','" + customer.OpeningDate+ "')";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                isExecuted = sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

            }catch(Exception exception)
            {
                
            }
            return isExecuted;
        }
        public void InsertAmount(Account account)
        {
            
            try
            {
                commandString = @"INSERT INTO Accounts VALUES ('" + account.AccountNo + "',"+account.Amount+")";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

            }
            catch (Exception exception)
            {

            }
            
        }

        public bool IsAccountNoDuplicate(Customer customer)
        {
            bool isDuplicate = false;

            commandString = @"SELECT * FROM Customers WHERE AccountNo= '"+customer.AccountNo+"'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if(dataTable.Rows.Count>0)
            {
                isDuplicate = true;
            }
            sqlConnection.Close();
            return isDuplicate;
        }
    }
}
