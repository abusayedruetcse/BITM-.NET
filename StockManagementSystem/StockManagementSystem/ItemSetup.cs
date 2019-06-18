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
        bool IsCategoryComboxAdded = false;
        bool IsCompanyComboxAdded = false;
        class Item
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public string CategoryID { get; set; }
            public string Company { get; set; }
            public string CompanyID { get; set; }
            public string ReorderLevel { get; set; }
        }
        public ItemSetup()
        {
            InitializeComponent();
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
                //1
                SqlConnection sqlConnection = new SqlConnection();
                string connectionString = @"Server=PC-301-17\SQLEXPRESS ;Database=StockManagementDB;Integrated Security=True";
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Item item = new Item();           
            item.Category = categoryComboBox.Text;
            item.CategoryID = IdFinding("Categories", "Name", item.Category);
            item.Company = companyComboBox.Text;
            item.CompanyID = IdFinding("Companies", "Name", item.Company);
            item.Name = itemNameTextBox.Text;
            item.ReorderLevel = reorderLevelTextBox.Text;
            if(IsDuplicate(item))
            {
                MessageBox.Show("Item is Duplicate!");
                return;
            }
            Insert(item);
        }
        private string IdFinding(string tableName,string columnName,string columnValue)
        {
            string id ="";
            try
            {
                //1
                SqlConnection sqlConnection = new SqlConnection();
                string connectionString = @"Server=PC-301-17\SQLEXPRESS ;Database=StockManagementDB;Integrated Security=True";
                sqlConnection.ConnectionString = connectionString;

                //2
                SqlCommand sqlCommand = new SqlCommand();
                string commandString = @"SELECT SL FROM "+tableName+" WHERE "+columnName+"='"+columnValue+"'";
                sqlCommand.CommandText = commandString;
                sqlCommand.Connection = sqlConnection;

                //3
                sqlConnection.Open();
                //4
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;

                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                id = dataTable.Rows[0]["SL"].ToString();

                //5
                sqlConnection.Close();               
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            return id;
        }
        private bool IsDuplicate(Item item)
        {
            bool isDuplicate = false;
            try
            {
                //1
                string connectionString = @"Server=PC-301-17\SQLEXPRESS ;Database=StockManagementDB;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                //2
                string commandString = @"SELECT ID FROM Items WHERE Name='"+item.Name+"' AND CategoryID ="+item.CategoryID+" AND CompanyID="+item.CompanyID;
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
                //3
                sqlConnection.Open();
                //4
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;

                DataTable dataTable = new DataTable();
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
                string connectionString = @"Server=PC-301-17\SQLEXPRESS ;Database=StockManagementDB;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = connectionString;

                //2
                string commandString = @"INSERT INTO Items VALUES('"+item.Name+"',"+item.CategoryID+" ,"+item.CompanyID+","+item.ReorderLevel+" )";
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
    }
}
