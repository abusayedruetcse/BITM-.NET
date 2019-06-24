using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MobileHandsetInformationSystem.Models;

namespace MobileHandsetInformationSystem.Repository
{
    public class MobileModelRepositoy
    {
        SqlConnection sqlConnection;
        string connectionString;
        SqlCommand sqlCommand;
        string commandString;
        DataTable dataTable;
        public MobileModelRepositoy()
        {
            //connectionString = @"Server=PC-301-17\SQLEXPRESS; Database=MobileModelInfoDB; Integrated Security=True";
            connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS; Database=MobileModelInfoDB; Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        public bool IsIMEIDuplicate(MobileModel mobileModel)
        {
            bool isDuplicate = false;
            try
            {
                commandString = @"SELECT * FROM MobileModels WHERE IMEI ='" + mobileModel.IMEI + "'";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    isDuplicate = true;
                }
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message);
            }
            return isDuplicate;
        }
        public int InsertModel(MobileModel mobileModel)
        {
            int isExecuted = 0;
            try
            {
                commandString = @"INSERT INTO MobileModels VALUES ('" + mobileModel.ModelName + "','" + mobileModel.IMEI + "'," + mobileModel.Price.ToString()+")";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                isExecuted = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message);             
            }
            return isExecuted;
        }
        public DataTable SearchByPrice(string range1,string range2)
        {
            try
            {
                commandString = @"SELECT * FROM MobileModels WHERE  Price BETWEEN "+range1+"  AND "+range2+" ";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    //displayDataGridView.DataSource = dataTable;
                }
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                //MessageBox.Show(exception.Message);
            }            

            return dataTable;
        }
        public DataTable SearchByIMEI(MobileModel mobileModel)
        {
            try
            {
                commandString = @"SELECT * FROM MobileModels WHERE  IMEI = '"+mobileModel.IMEI+"' ";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                
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
