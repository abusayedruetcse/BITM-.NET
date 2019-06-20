using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace MyWinApp.Repository
{
    public class StudentRepository
    {
        string connectionString = @"Server=PC-301-17\SQLEXPRESS; Database=StudentDB; Integrated Security=True";
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        public DataTable LoadDistrict()
        {
            DataTable dataTable = new DataTable(); ;
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                commandString = @"SELECT * FROM Districts";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    //districtComboBox.DataSource = dataTable;
                }

                sqlConnection.Close();               

            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message);
            }
            return dataTable;
        }
    }
}
