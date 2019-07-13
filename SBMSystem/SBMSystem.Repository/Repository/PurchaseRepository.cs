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
    public class PurchaseRepository
    {
        string connectionString;
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        public PurchaseRepository()
        {
            //connectionString = @"Server=PC-301-17\SQLEXPRESS; Database=SBMSDB;Integrated Security=True";
            connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS; Database=SBMSDB;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        public DataTable LoadSupplierToComboBox()
        {
            commandString = @"SELECT * FROM Suppliers";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
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
        public DataTable GetProductByCode(Product product)
        {
            commandString = @"SELECT * FROM Products WHERE Code='"+product.Code+"'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }
        public bool AddPurchase(Purchase purchase)
        {
            int isExecuted = 0;
            commandString = @"INSERT INTO Purchases VALUES('"+purchase.SupplierCode+"','"+purchase.BillNo+"','"+purchase.Date+"','"+purchase.ProductCode+"','"+purchase.ManufacturedDate+"','"+purchase.ExpireDate+"',"+purchase.Quantity+","+purchase.UnitPrice+","+purchase.MRP+",'"+purchase.Remarks+"')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            isExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return isExecuted > 0;
        } 
        public int GetAvailableQuantity(Product product)
        {
            commandString = @"SELECT AvailableQuantity FROM Products WHERE Code='" + product.Code + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return Convert.ToInt32(dataTable.Rows[0]["AvailableQuantity"]);
        }
        public bool UpdateProduct(Product product)
        {
            int isExecuted = 0;
            commandString = @"UPDATE Products SET AvailableQuantity= "+product.AvailableQuantity+ ", CurrentMRP="+product.CurrentMRP+ ",UnitPrice="+product.UnitPrice+" WHERE Code='" + product.Code + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            isExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return isExecuted > 0;
        }


    }
}
