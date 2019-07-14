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
    public class SalesRepository
    {
        string connectionString;
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        public SalesRepository()
        {
            //connectionString = @"Server=PC-301-17\SQLEXPRESS; Database=SBMSDB;Integrated Security=True";
            connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS; Database=SBMSDB;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        public DataTable LoadCustomerToComboBox()
        {
            commandString = @"SELECT * FROM Customers";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }
        public int GetLoyaltyPoint(Customer customer)
        {
            commandString = @"SELECT LoyaltyPoint FROM Customers WHERE Code='"+customer.Code+"'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return Convert.ToInt32(dataTable.Rows[0]["LoyaltyPoint"]);
        }
        public DataTable LoadProductToComboBox()
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
        public DataTable GetAvailableQuantityAndUnitPrice(Product product)
        {
            commandString = @"SELECT AvailableQuantity,UnitPrice FROM Products WHERE Code='" + product.Code + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }
        public bool AddSales(Sales sales)
        {
            int isExecuted = 0;
            commandString = @"INSERT INTO Sales VALUES('"+sales.CustomerCode+"','"+sales.Date+"','"+sales.ProductCode+"',"+sales.Quantity+","+sales.PayableAmount+")";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            isExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return isExecuted > 0;
        }
    }
}
