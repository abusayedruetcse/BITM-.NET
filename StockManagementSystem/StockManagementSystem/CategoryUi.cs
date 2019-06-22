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
    public partial class CategoryUi : Form
    {        
        string connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS;Database=StockManagementDB;Integrated Security=True";
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        Category category;
        public CategoryUi()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
            category = new Category();
        }
        private void CategorySetup_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {           
            string name = "";
            if (SaveButton.Text.Equals("Save"))
            {               
                name = nameTextBox.Text;
                if(String.IsNullOrEmpty(name))
                {
                    messageLabel.Text = "Name Field is Empty";
                    return;
                }
                Insert(name);                
            }
            else
            {
                name = nameTextBox.Text;
                if (String.IsNullOrEmpty(name))
                {
                    messageLabel.Text = "Name Field is Empty";
                    return;
                }
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

                //2
                commandString = @"INSERT INTO Categories (Name) VALUES('"+name+"')";
                sqlCommand = new SqlCommand();
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
                

                //2
                sqlCommand = new SqlCommand();
                commandString = "UPDATE Categories SET Name =  '" + name + "' WHERE ID = " + category.ID + "";
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
                
                commandString = @"SELECT * FROM Categories";
                sqlCommand = new SqlCommand(commandString, sqlConnection);
                //3
                sqlConnection.Open();
                //4
                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                categoryDataGridView.DataSource = dataTable;                
                //5
                sqlConnection.Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            foreach (DataGridViewRow row in categoryDataGridView.Rows)
                row.Cells["SL"].Value = (row.Index + 1).ToString();
            categoryDataGridView.RowHeadersVisible = false;

        }

        private void categoryDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(categoryDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                categoryDataGridView.CurrentRow.Selected = true;
                nameTextBox.Text = categoryDataGridView.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn1"].FormattedValue.ToString();
                category.ID = Convert.ToInt32(categoryDataGridView.Rows[e.RowIndex].Cells["iDDataGridViewTextBoxColumn"].FormattedValue);
                SaveButton.Text = "Update";

            }
        }

        
    }
}
