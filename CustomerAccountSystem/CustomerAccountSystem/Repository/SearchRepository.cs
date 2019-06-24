using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerAccountSystem.Models;
using System.Data;
using System.Data.SqlClient;

namespace CustomerAccountSystem.Repository
{
    public class SearchRepository
    {
        string connectionString;
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        public SearchRepository()
        {
            connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS; Database=CustomerInfoDB ; Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        public DataTable ShowCustomer(Customer customer)
        {
            commandString = @"SELECT Name,c.AccountNo,c.OpeningDate,a.Amount AS Balance FROM Customers AS c LEFT JOIN Accounts AS a ON c.AccountNo=a.AccountNo WHERE c.AccountNo= '" + customer.AccountNo+"'";
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
