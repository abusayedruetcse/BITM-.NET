using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystem
{
    public partial class ItemSetup : Form
    {
        public ItemSetup()
        {
            InitializeComponent();
        }

        private void categoryComboBox_Click(object sender, EventArgs e)
        {
            ComboxBoxWithSelect("Categories");             
        }

        private void companyComboBox_Click(object sender, EventArgs e)
        {
            ComboxBoxWithSelect("Companies");
        }
        private void ComboxBoxWithSelect(string tableName)
        {
            try
            {
                //1
                SqlConnection sqlConnection = new SqlConnection();
                string connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS;Database=StockManagementDB;Integrated Security=True";
                sqlConnection.ConnectionString = connectionString;

                //2
                SqlCommand sqlCommand = new SqlCommand();
                string commandString = @"SELECT * FROM "+tableName;
                sqlCommand.CommandText = commandString;
                sqlCommand.Connection = sqlConnection;

                //3
                sqlConnection.Open();
                //4
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;

                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if(tableName.Equals("Companies"))
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        companyComboBox.Items.Add(dataRow["Name"].ToString());
                    }
                }
                else
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        categoryComboBox.Items.Add(dataRow["Name"].ToString());
                    }
                }
                
                //5
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
    }
}
