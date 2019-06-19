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
using StockManagementSystem.Models;

namespace StockManagementSystem
{
    public partial class CategorySetup : Form
    {
        int ID;
        public CategorySetup()
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
                    messageLabel.Text = "Saved Successfully";
                }
                else
                {
                    messageLabel.Text = "Save Failed!";
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
                string commandString = "UPDATE Categories SET Name =  '" + name + "' WHERE ID = " + ID + "";
                sqlCommand.CommandText = commandString;
                sqlCommand.Connection = sqlConnection;

                //3
                sqlConnection.Open();

                //4 
                int isExecuted = 0;
                isExecuted= sqlCommand.ExecuteNonQuery();
                if(isExecuted>0)
                {
                    messageLabel.Text = "Updated Successfully";
                }
                else
                {
                    messageLabel.Text = "Update Failed!";
                }

                //5
                sqlConnection.Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }            
        }
        private void Display()
        {
            try
            {
                //1
                string connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS ;Database=StockManagementDB;Integrated Security=True";
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

        private void categoryDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(categoryDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                categoryDataGridView.CurrentRow.Selected = true;
                nameTextBox.Text = categoryDataGridView.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
                ID = Convert.ToInt32(categoryDataGridView.Rows[e.RowIndex].Cells["ID"].FormattedValue);
                SaveButton.Text = "Update";

            }
        }
    }
}
