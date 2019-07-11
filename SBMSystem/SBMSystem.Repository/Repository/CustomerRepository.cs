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
    public class CustomerRepository
    {
        string connectionString;
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        public CustomerRepository()
        {
            //connectionString = @"Server=PC-301-17\SQLEXPRESS; Database=SBMSDB;Integrated Security=True";
            connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS; Database=SBMSDB;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        public bool AddCustomer(Customer customer)
        {
            int isExecuted = 0;
            commandString = @"INSERT INTO Customers VALUES('" + customer.Code + "','" + customer.Name + "','" + customer.Address + "','"+customer.Email+"' ,' " + customer.Contact + " ','" + customer.ImageCustomer+ "',"+customer.LoyaltyPoint+")";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            isExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return isExecuted > 0;
        }
    }
}
