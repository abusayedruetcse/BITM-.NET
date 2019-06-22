using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystem.Models;

namespace StockManagementSystem
{
    public partial class StockInUi : Form
    {
        string connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS ;Database=StockManagementDB;Integrated Security=True";
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        StockIn stockIn;
        Item item;
        public StockInUi()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
            stockIn = new StockIn();
            item = new Item();
        }

        private void StockIn_Load(object sender, EventArgs e)
        {
            
            companyComboBox.Text = "-Select-";
            categoryComboBox.Text = "-Select-";
            itemComboBox.Text = "-Select-";
            reorderLevelTextBox.Text = "<View>";
            availableQuantityTextBox.Text = "<View>";

            //company
            commandString = @"SELECT * FROM Companies";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            companyComboBox.DataSource = dataTable;
            if (dataTable.Rows.Count ==0)
            {
                companyComboBox.Text = "";
            }

            sqlConnection.Close();
            //category
            commandString = @"SELECT * FROM Categories";            
            try
            {
                sqlCommand = new SqlCommand(commandString, sqlConnection);
                sqlConnection.Open();

                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                categoryComboBox.DataSource = dataTable;
                if (dataTable.Rows.Count == 0)
                {
                    categoryComboBox.Text = "";
                }
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }


        }

        private void companyComboBox_Click(object sender, EventArgs e)
        {                                  
            item.CompanyID = Convert.ToInt32(companyComboBox.SelectedValue);            
        }

        private void categoryComboBox_Click(object sender, EventArgs e)
        {                     
            item.CategoryID = Convert.ToInt32(categoryComboBox.SelectedValue);
        }

        private void itemComboBox_Click(object sender, EventArgs e)
        {                     
            try
            {
                commandString = @"SELECT * FROM Items WHERE CategoryID =" + categoryComboBox.SelectedValue + " AND CompanyID=" + companyComboBox.SelectedValue + "";

                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                itemComboBox.DataSource = dataTable;
                if (dataTable.Rows.Count ==0)
                {
                    itemComboBox.Text = "";
                    MessageBox.Show("Not found");
                }
                
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
       

        private void SaveButton_Click(object sender, EventArgs e)
        {
            
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            commandString = @"SELECT * FROM Items WHERE Name='" + itemComboBox.Text + "' AND CategoryID =" + categoryComboBox.SelectedValue + " AND CompanyID=" + companyComboBox.SelectedValue + "";
            try
            {
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    reorderLevelTextBox.Text = dataTable.Rows[0]["ReorderLevel"].ToString();
                    availableQuantityTextBox.Text = dataTable.Rows[0]["AvailableQuantity"].ToString();
                }
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            string sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
            stockInQuantityTextBox.Text = sysUIFormat;
        }

        
    }
}
