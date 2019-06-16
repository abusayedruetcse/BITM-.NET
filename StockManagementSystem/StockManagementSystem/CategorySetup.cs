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
    public partial class CategorySetup : Form
    {
        public CategorySetup()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string name = "";
            name = nameTextBox.Text;
            Insert(name);
            Display();
        }
        private void Insert(string name)
        {
            try
            {
                //1
                string connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS;Database=StockManagementDB;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = connectionString;

                //2
                string commandString = @"INSERT INTO Categories (Name) VALUES('"+name+"')";
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = commandString;
                sqlCommand.Connection = sqlConnection;

                //3
                sqlConnection.Open();

                //4
                int isExecuted = 0;
                isExecuted= sqlCommand.ExecuteNonQuery(); 
                if (isExecuted>0)
                {
                    MessageBox.Show("Saved Successfully");
                }
                else
                {
                    MessageBox.Show("Save Failed!");
                }
                //5
                sqlConnection.Close();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void Display()
        {
            try
            {
                //1
                string connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS;Database=StockManagementDB;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                //2
                string commandString = @"SELECT * FROM Categories";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
                //3
                sqlConnection.Open();
                //4
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;

                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                categoryDataGridView.DataSource = dataTable;
                //5
                sqlConnection.Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        
    }
}
