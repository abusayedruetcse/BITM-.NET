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
    public partial class CompanySetup : Form
    {
        int SL = 0;
        public CompanySetup()
        {
            InitializeComponent();
            Display();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string name = "";
            if (SaveButton.Text.Equals("Save"))
            {
                name = nameTextBox.Text;
                Insert(name);
            }
            else
            {
                name = nameTextBox.Text;
                Update(name);
                SaveButton.Text = "Save";
            }
            nameTextBox.Text = "";
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
                string commandString = @"INSERT INTO Companies (Name) VALUES('" + name + "')";
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = commandString;
                sqlCommand.Connection = sqlConnection;

                //3
                sqlConnection.Open();

                //4
                int isExecuted = 0;
                isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
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
        private void Update(string name)
        {
            try
            {
                //1
                SqlConnection sqlConnection = new SqlConnection();
                string connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS ; Database=StockManagementDB ; Integrated Security=true";
                sqlConnection.ConnectionString = connectionString;

                //2
                SqlCommand sqlCommand = new SqlCommand();
                string commandString = "UPDATE Companies SET Name =  '" + name + "' WHERE SL = " + SL + "";
                sqlCommand.CommandText = commandString;
                sqlCommand.Connection = sqlConnection;

                //3
                sqlConnection.Open();

                //4 
                int isExecuted = 0;
                isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    MessageBox.Show("Updated Successfully");
                }
                else
                {
                    MessageBox.Show("Update Failed!");
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
                string commandString = @"SELECT * FROM Companies";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
                //3
                sqlConnection.Open();
                //4
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;

                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                companyDataGridView.DataSource = dataTable;
                //5
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void companyDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (companyDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    companyDataGridView.CurrentRow.Selected = true;
                    nameTextBox.Text = companyDataGridView.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
                    SL = Convert.ToInt32(companyDataGridView.Rows[e.RowIndex].Cells["SL"].FormattedValue);
                    SaveButton.Text = "Update";

                }
            }catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }
    }
}
