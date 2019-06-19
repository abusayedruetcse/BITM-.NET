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
    public partial class StockInForm : Form
    {
        string connectionString = @"Server=DESKTOP-AAHS936\SQLEXPRESS ;Database=StockManagementDB;Integrated Security=True";
        SqlConnection sqlConnection;
        string commandString;
        SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        StockIn stockIn;
        public StockInForm()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
            stockIn = new StockIn();
        }

        private void StockIn_Load(object sender, EventArgs e)
        {
            companyComboBox.Text = "-Select-";
            categoryComboBox.Text = "-Select-";
            itemComboBox.Text = "-Select-";
            reorderLevelTextBox.Text = "<View>";
            availableQuantityTextBox.Text = "<View>";
        }

        private void companyComboBox_Click(object sender, EventArgs e)
        {
            commandString = @"SELECT * FROM Companies";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            if(dataTable.Rows.Count>0)
            {
                companyComboBox.DataSource = dataTable;
            }
            sqlConnection.Close();
        }

        private void categoryComboBox_Click(object sender, EventArgs e)
        {
            if(companyComboBox.Text.Equals("-Select-"))
            {
                messageLabel.Text = "Select any Company First!";
                return;
            }
            try
            {
                commandString = @"SELECT DISTINCT cat.Name FROM  Categories AS cat LEFT JOIN Items As i ON i.CategoryID=cat.ID WHERE i.CompanyID= " + companyComboBox.SelectedValue + "";
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    categoryComboBox.DataSource = dataTable;
                }
                sqlConnection.Close();
            }catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }
    }
}
