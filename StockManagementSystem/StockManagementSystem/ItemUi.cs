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
    public partial class ItemUi : Form
    {
        bool IsCategoryComboxAdded = false;
        bool IsCompanyComboxAdded = false;
        string connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS ;Database=StockManagementDB;Integrated Security=True";
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        Item item;
        public ItemUi()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
            item = new Item();
        }

        private void categoryComboBox_Click(object sender, EventArgs e)
        {
            if(!IsCategoryComboxAdded)
            {
                ComboxBoxWithSelect("Categories");
            }
            IsCategoryComboxAdded = true;
        }

        private void companyComboBox_Click(object sender, EventArgs e)
        {
            if(!IsCompanyComboxAdded)
            {
                ComboxBoxWithSelect("Companies");
            }
            IsCompanyComboxAdded = true;
        }
        private void ComboxBoxWithSelect(string tableName)
        {
            try
            { 
                commandString = @"SELECT * FROM " + tableName;
                sqlCommand = new SqlCommand();                
                sqlCommand.CommandText = commandString;
                sqlCommand.Connection = sqlConnection;

                //3
                sqlConnection.Open();
                //4
                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if(tableName.Equals("Companies"))
                {
                    companyComboBox.DataSource = dataTable;
                }
                else
                {
                    categoryComboBox.DataSource = dataTable;
                }
                
                //5
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {                              
            item.CategoryID = Convert.ToInt32(categoryComboBox.SelectedValue);
            item.CompanyID = Convert.ToInt32(companyComboBox.SelectedValue);
            item.Name = itemNameTextBox.Text;
            item.ReorderLevel = reorderLevelTextBox.Text;
            if(IsDuplicate(item))
            {
                messageLabel.Text = "Item is Duplicate!";
                return;
            }
            Insert(item);
            //cleaning
            categoryComboBox.Text = "";
            companyComboBox.Text = "";
            itemNameTextBox.Text = "";
            reorderLevelTextBox.Text = "";
        }
        
        private bool IsDuplicate(Item item)
        {
            bool isDuplicate = false;
            try
            {
                //1
                commandString = @"SELECT ID FROM Items WHERE Name='"+item.Name+"' AND CategoryID ="+item.CategoryID+" AND CompanyID="+item.CompanyID;
                sqlCommand = new SqlCommand(commandString, sqlConnection);
                //3
                sqlConnection.Open();
                //4
                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;

                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                
                if(dataTable!=null && dataTable.Rows.Count>0)
                {
                    isDuplicate = true;
                }
                
                //5
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            return isDuplicate;
        }
        private void Insert(Item item)
        {
            try
            {
                //1
                commandString = @"INSERT INTO Items VALUES('"+item.Name+"',"+item.CategoryID+" ,"+item.CompanyID+","+item.ReorderLevel+", 0 )";
                sqlCommand = new SqlCommand();
                sqlCommand.CommandText = commandString;
                sqlCommand.Connection = sqlConnection;

                //3
                sqlConnection.Open();

                //4
                int isExecuted = 0;
                isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
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
    }
}
