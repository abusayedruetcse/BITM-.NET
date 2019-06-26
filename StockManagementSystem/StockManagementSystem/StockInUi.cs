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
using StockManagementSystem.BLL;

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
        StockInManager _stockInManager;
        public StockInUi()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
            stockIn = new StockIn();
            item = new Item();
            _stockInManager = new StockInManager();
        }

        
        private void StockIn_Load(object sender, EventArgs e)
        {
            //company
            dataTable= _stockInManager.LoadCompanyToComboBox();
            companyComboBox.DataSource = dataTable;
            if (dataTable.Rows.Count == 0)
            {
                companyComboBox.Text = "";
                messageLabel.Text = "No Company in Database";
            }
            //category      
            dataTable = _stockInManager.LoadCategoryToComboBox();
            categoryComboBox.DataSource = dataTable;
            if (dataTable.Rows.Count == 0)
            {
                companyComboBox.Text = "";
                messageLabel.Text = "No Category in Database";
            }
            //Cleaning Text fields.
            companyComboBox.Text = "-Select-";
            categoryComboBox.Text = "-Select-";
            itemComboBox.Text = "-Select-";
            reorderLevelTextBox.Text = "<View>";
            availableQuantityTextBox.Text = "<View>";
        }

        private void companyComboBox_Click(object sender, EventArgs e)
        {             
            item.CompanyID = Convert.ToInt32(companyComboBox.SelectedValue);            
        }

        private void categoryComboBox_Click(object sender, EventArgs e)
        {
            if (companyComboBox.Text.Equals("-Select-") || companyComboBox.Text == null)
            {
                messageLabel.Text = "Select a company first";
                return;
            }
            item.CategoryID = Convert.ToInt32(categoryComboBox.SelectedValue);
        }

        private void itemComboBox_Click(object sender, EventArgs e)
        {
            if (categoryComboBox.Text.Equals("-Select-") || categoryComboBox.Text == null)
            {
                messageLabel.Text = "Select a category first";
                return;
            }
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
                    messageLabel.Text = "Not found";
                }
                
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
       
        private void UpdateItem(Item item)
        {
            int isExecuted = 0;
            commandString = @"UPDATE Items SET AvailableQuantity="+item.AvailableQuantity+"  WHERE ID="+item.ID+"";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            isExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        private void UpdateStockIn(StockIn stockIn)
        {
            int isExecuted = 0;
            commandString = @"UPDATE StockIns SET Quantity=" + stockIn.Quantity + "  WHERE ID=" + stockIn.ID + "";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            isExecuted = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(SaveButton.Text.Equals("Confirm"))
            {
                int updateQuantity = Convert.ToInt32(stockInQuantityTextBox.Text);
                item.AvailableQuantity += updateQuantity;
                stockIn.Quantity = updateQuantity;
                UpdateItem(item);
                UpdateStockIn(stockIn);
                //cleaning
                
                SaveButton.Text = "Save";
            } 
            else
            {
                //stockIn.Date= DateTime.Now.ToString("yyyy/MM/dd");
                if (companyComboBox.Text.Equals("-Select-"))
                {
                    messageLabel.Text="Enter a company";
                    return;
                }
                if (categoryComboBox.Text.Equals("-Select-"))
                {
                    messageLabel.Text = "Enter a category";
                    return;
                }
                if (itemComboBox.Text.Equals("-Select-"))
                {
                    messageLabel.Text = "Enter an Item";
                    return;
                }
                stockIn.Date = stockInDateTimePicker.Value.ToString("yyyy-MM-dd");
                stockIn.ItemID = Convert.ToInt32(itemComboBox.SelectedValue);
                if (String.IsNullOrEmpty(stockInQuantityTextBox.Text))
                {
                    messageLabel.Text = "Enter a quantity!";                   
                    return;
                }
                stockIn.Quantity = Convert.ToInt32(stockInQuantityTextBox.Text);
                InsertStockIn(stockIn);
                //update avaiableQuantity
                item.ID = stockIn.ItemID;          
                dataTable = GetItem(item);
                int currentQuantity = Convert.ToInt32(dataTable.Rows[0]["AvailableQuantity"]);
                item.AvailableQuantity = currentQuantity + stockIn.Quantity;
                UpdateItem(item);

            }
            companyComboBox.Text = "-Select-";
            categoryComboBox.Text = "-Select-";
            itemComboBox.Text = "-Select-";
            reorderLevelTextBox.Text = "<View>";
            availableQuantityTextBox.Text = "<View>";
            stockInQuantityTextBox.Text = "";
            DisplayRecords();
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
            //working with dataGridView

            DisplayRecords();



        }
        private void DisplayRecords()
        {
            commandString = @"SELECT s.ID AS ID,ItemID, Name AS ItemName,Date,Quantity FROM StockIns AS s LEFT OUTER JOIN Items AS i ON s.ItemID=i.ID ORDER BY s.Date DESC";

            try
            {
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                stockInDataGridView.DataSource = dataTable;
                if (dataTable.Rows.Count > 0)
                {
                    //MessageBox.Show("No any records");
                }
                else
                {
                    messageLabel.Text = "No any records";
                }

                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            foreach(DataGridViewRow row in stockInDataGridView.Rows)
            {
                row.Cells["SL"].Value = (row.Index + 1).ToString();
                row.Cells["Action"].Value = Convert.ToString("Edit");
            }
        }
        private void  InsertStockIn(StockIn stockIn)
        {
            int isExecuted = 0;
            commandString = @"INSERT INTO StockIns VALUES('" + stockIn.Date + "'," + stockIn.Quantity+ "," + stockIn.ItemID + ")";
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();
            isExecuted= sqlCommand.ExecuteNonQuery(); 
            sqlConnection.Close();
            
            if(isExecuted>0)
            {
                messageLabel.Text = "Saved";

            }
            else
            {
                messageLabel.Text = "Save Failed";
            }
        }

        private void stockInDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {           
            int currentQuantity = Convert.ToInt32(stockInDataGridView.Rows[e.RowIndex].Cells["quantityDataGridViewTextBoxColumn"].Value);
            item.ID = Convert.ToInt32(stockInDataGridView.Rows[e.RowIndex].Cells["itemIDDataGridViewTextBoxColumn"].Value);
            dataTable = GetItem(item);
            //display into textbox
            if(dataTable.Rows.Count>0)
            {
                companyComboBox.SelectedValue = dataTable.Rows[0]["CompanyID"];                
                categoryComboBox.SelectedValue = dataTable.Rows[0]["CategoryID"];               
                itemComboBox.Text = dataTable.Rows[0]["Name"].ToString();
                reorderLevelTextBox.Text = dataTable.Rows[0]["ReorderLevel"].ToString();
                availableQuantityTextBox.Text = dataTable.Rows[0]["AvailableQuantity"].ToString();
            }
            stockInQuantityTextBox.Text = currentQuantity.ToString();
            SaveButton.Text = "Confirm";
            //updating for item     
            item.AvailableQuantity = Convert.ToInt32(availableQuantityTextBox.Text);
            item.AvailableQuantity -= currentQuantity; //reduce currentQuantity
            
            //updating for StockIn
            stockIn.ID= Convert.ToInt32(stockInDataGridView.Rows[e.RowIndex].Cells["iDDataGridViewTextBoxColumn"].Value);   
        }             
        private DataTable GetItem(Item item)
        {
            commandString = @"SELECT * FROM Items WHERE ID="+item.ID+"";
            try
            {
                sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();

                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            return dataTable;
        }

        
    }
}
