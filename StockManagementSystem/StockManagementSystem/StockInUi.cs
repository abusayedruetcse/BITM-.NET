using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        DataTable dataTable;
        StockIn stockIn;
        Item item;
        StockInManager _stockInManager;
        History history;
        public StockInUi()
        {
            InitializeComponent();            
            stockIn = new StockIn();
            item = new Item();
            _stockInManager = new StockInManager();
            history = new History();
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
            dataTable = _stockInManager.LoadFilteredItemToComboBox(Convert.ToInt32(categoryComboBox.SelectedValue), Convert.ToInt32(companyComboBox.SelectedValue));
            itemComboBox.DataSource = dataTable;
            if (dataTable.Rows.Count == 0)
            {
                itemComboBox.Text = "";
                messageLabel.Text = "Item Not found";
            }
        }
              
        private void SaveButton_Click(object sender, EventArgs e)
        {
            history.UserID = UserAccount.ID;
            history.TableName = "StockIns";
            history.DateAndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (SaveButton.Text.Equals("Confirm"))
            {
                history.TableRowNo = stockIn.ID;
                int updateQuantity = Convert.ToInt32(stockInQuantityTextBox.Text);
                item.AvailableQuantity += updateQuantity;
                stockIn.Quantity = updateQuantity;
                _stockInManager.UpdateItem(item);
                _stockInManager.UpdateStockIn(stockIn,history);
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
                dataTable = _stockInManager.GetItem(item);
                int currentQuantity = Convert.ToInt32(dataTable.Rows[0]["AvailableQuantity"]);
                item.AvailableQuantity = currentQuantity + stockIn.Quantity;
                _stockInManager.UpdateItem(item);

            }
            companyComboBox.Text = "-Select-";
            categoryComboBox.Text = "-Select-";
            itemComboBox.Text = "-Select-";
            reorderLevelTextBox.Text = "<View>";
            availableQuantityTextBox.Text = "<View>";
            stockInQuantityTextBox.Text = "";
            DisplayRecords();
        }
        private void InsertStockIn(StockIn stockIn)
        {
            int isExecuted = 0;
            isExecuted = _stockInManager.InsertStockIn(stockIn,history);
            if (isExecuted > 0)
            {
                messageLabel.Text = "Saved";
            }
            else
            {
                messageLabel.Text = "Save Failed";
            }
        }

        private void DisplayRecords()
        {
            dataTable = _stockInManager.DisplayRecords();
            stockInDataGridView.DataSource = dataTable;
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No any records");
            }
            foreach (DataGridViewRow row in stockInDataGridView.Rows)
            {
                row.Cells["SL"].Value = (row.Index + 1).ToString();
                row.Cells["Action"].Value = Convert.ToString("Edit");
                row.Cells["dateDataGridViewTextBoxColumn"].Value = Convert.ToDateTime(row.Cells["dateDataGridViewTextBoxColumn"].Value).ToString("dd-MM-yyyy");
            }
            history.TableRowNo = stockInDataGridView.Rows.Count + 1;
        }        
        
        private void stockInDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {           
            int currentQuantity = Convert.ToInt32(stockInDataGridView.Rows[e.RowIndex].Cells["quantityDataGridViewTextBoxColumn"].Value);
            item.ID = Convert.ToInt32(stockInDataGridView.Rows[e.RowIndex].Cells["itemIDDataGridViewTextBoxColumn"].Value);
            dataTable = _stockInManager.GetItem(item);
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

        private void itemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataTable = _stockInManager.GetAvailableQuantityAndReorderLevel(Convert.ToInt32(categoryComboBox.SelectedValue), Convert.ToInt32(companyComboBox.SelectedValue), itemComboBox.Text);
            if (dataTable.Rows.Count > 0)
            {
                reorderLevelTextBox.Text = dataTable.Rows[0]["ReorderLevel"].ToString();
                availableQuantityTextBox.Text = dataTable.Rows[0]["AvailableQuantity"].ToString();
            }
            //Display on DataGridView
            DisplayRecords();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuUi menuUi = new MenuUi();
            menuUi.Show();
        }
    }
}
