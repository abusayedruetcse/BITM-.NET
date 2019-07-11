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
    public class SupplierRepository
    {        
        string connectionString;
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        public SupplierRepository()
        {
            //connectionString = @"Server=PC-301-17\SQLEXPRESS; Database=SBMSDB;Integrated Security=True";
            connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS; Database=SBMSDB;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        public bool AddSupplier(Supplier supplier)
        {
            int isExecuted = 0;
            commandString = @"INSERT INTO Suppliers VALUES('"+supplier.Code+"','"+supplier.Name+"','"+supplier.Address+"','"+supplier.Email+"','"+supplier.Contact+"','"+supplier.ImageLogo+"','"+supplier.ContactPerson+"')";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            isExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return isExecuted > 0;
        }
        public bool IsCodeDuplicate(Supplier supplier)
        {
            commandString = @"SELECT * FROM Suppliers WHERE Code='" + supplier.Code + "'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable.Rows.Count > 0;
        }
    }
}
