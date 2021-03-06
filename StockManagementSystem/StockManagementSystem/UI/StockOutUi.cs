﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystem.Models;
using StockManagementSystem.BLL;

namespace StockManagementSystem
{
    public partial class StockOutUi : Form
    {
        DataTable dataTable;
        StockOutManager _stockOutManager;
        Item item;
        List<StockOut> listStockOut;
        StockOut stockOut;
        History history;
        public StockOutUi()
        {
            InitializeComponent();
            _stockOutManager = new StockOutManager();
            item = new Item();
            listStockOut = new List<StockOut>();
            history = new History();
        }

        private void StockOutUi_Load(object sender, EventArgs e)
        {
            stockOutDataGridView.DataSource = null;
            //Preview 
            companyComboBox.Text = "-Select-";
            categoryComboBox.Text = "-Select-";
            itemComboBox.Text = "-Select-";
            reorderLevelTextBox.Text = "<View>";
            availableQuantityTextBox.Text = "<View>";
        }

        private void companyComboBox_Click(object sender, EventArgs e)
        {
            messageLabel.ForeColor = Color.Red;
            messageLabel.Text = "";
            dataTable = _stockOutManager.LoadCompanyToComboBox();
            companyComboBox.DataSource = dataTable;
            if (dataTable.Rows.Count == 0)
            {
                messageLabel.Text = "No company in Database";
                return;
            }
        }

        private void categoryComboBox_Click(object sender, EventArgs e)
        {
            messageLabel.ForeColor = Color.Red;
            if (companyComboBox.Text.Equals("-Select-") || companyComboBox.Text == "")
            {
                messageLabel.Text = "Select Company";
                return;
            }                
            dataTable = _stockOutManager.LoadFilteredCategoryToComboBox(Convert.ToInt32(companyComboBox.SelectedValue));
            categoryComboBox.DataSource = dataTable;
            if (dataTable.Rows.Count == 0)
            {
                messageLabel.Text = "No category with this company in Database";
                categoryComboBox.Text = "-Select-";
                return;
            }          
        }

        private void itemComboBox_Click(object sender, EventArgs e)
        {
            messageLabel.ForeColor = Color.Red;
            messageLabel.Text = "";
            reorderLevelTextBox.Text = "";
            availableQuantityTextBox.Text = "";
            if (companyComboBox.Text.Equals("-Select-")||companyComboBox.Text=="")
            {
                messageLabel.Text = "Select Company";
                return;
            }
            if (categoryComboBox.Text.Equals("-Select-") || categoryComboBox.Text == "")
            {
                messageLabel.Text = "Select Category";
                return;
            }
            dataTable = _stockOutManager.LoadFilteredItemToComboBox(Convert.ToInt32(categoryComboBox.SelectedValue), Convert.ToInt32(companyComboBox.SelectedValue));
            itemComboBox.DataSource = dataTable;
            if(dataTable.Rows.Count==0)
            {
                messageLabel.Text = "No item Found";
                return;
            }            
        }      
        
        private void AddButton_Click(object sender, EventArgs e)
        {
            messageLabel.ForeColor = Color.Red;
            messageLabel.Text = "";
            if (companyComboBox.Text.Equals("-Select-") || companyComboBox.Text == "")
            {
                messageLabel.Text = "Select Company";
                return;
            }
            if (categoryComboBox.Text.Equals("-Select-") || categoryComboBox.Text == "")
            {
                messageLabel.Text = "Select Category";
                return;
            }
            if (itemComboBox.Text.Equals("-Select-") || itemComboBox.Text == "")
            {
                messageLabel.Text = "Select Item";
                return;
            }
            stockOut = new StockOut();
            messageLabel.Text = "";
            //Stockout Quantity textfield checking
            if (String.IsNullOrEmpty(stockOutQuantityTextBox.Text))
            {
                messageLabel.Text = "Enter Stock Out Quantity";
                return;
            }
            if(System.Text.RegularExpressions.Regex.IsMatch(stockOutQuantityTextBox.Text,"[^0-9]"))
            {
                messageLabel.Text = "Enter Numeric Digits";
                return;
            }
            //avaiability checking
            int quantityOut = Convert.ToInt32(stockOutQuantityTextBox.Text);
            int availableQuantity = Convert.ToInt32(availableQuantityTextBox.Text);
            int reorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);
            if(quantityOut>availableQuantity)
            {
                messageLabel.Text = "No Product as Your order";
                return;
            } 
            if((availableQuantity-quantityOut)<=reorderLevel)
            {
                messageLabel.Text = "Item is Under reorderLevel";
            }
            stockOut.ItemName = itemComboBox.Text;
            stockOut.CompanyName = companyComboBox.Text;
            stockOut.Quantity = Convert.ToInt32(stockOutQuantityTextBox.Text);
            item.Name = itemComboBox.Text;
            item.CategoryID = Convert.ToInt32(categoryComboBox.SelectedValue);
            item.CompanyID = Convert.ToInt32(companyComboBox.SelectedValue);
            dataTable = _stockOutManager.GetAvailableQuantityAndReorderLevel(item);
            stockOut.ItemID = Convert.ToInt32(dataTable.Rows[0]["ID"].ToString());
            listStockOut.Add(stockOut);
            stockOutDataGridView.DataSource = null;
            stockOutDataGridView.DataSource = listStockOut;
            //Adding SI column
            foreach(DataGridViewRow row in stockOutDataGridView.Rows)
            {
                row.Cells["SL"].Value = (row.Index + 1).ToString();
            }

            //Preview 
            companyComboBox.Text = "-Select-";
            categoryComboBox.Text = "-Select-";
            itemComboBox.Text = "-Select-";
            reorderLevelTextBox.Text = "<View>";
            availableQuantityTextBox.Text = "<View>";
            stockOutQuantityTextBox.Text = "";

        }

        private void SellButton_Click(object sender, EventArgs e)
        {
            UpdateStackOut("Sell");
        }

        private void LostButton_Click(object sender, EventArgs e)
        {
            UpdateStackOut("Lost");
        }

        private void DamageButton_Click(object sender, EventArgs e)
        {
            UpdateStackOut("Damage");
        }
        private void UpdateStackOut(string action)
        {
            messageLabel.ForeColor = Color.Red;
            if(stockOutDataGridView.Rows.Count==0||stockOutDataGridView.DataSource==null)
            {
                messageLabel.Text = "No Item is added to DataGridView";
                return;
            }
            history.UserID = UserAccount.ID;
            history.TableName = "StockOuts";
            history.DateAndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            history.TableRowNo = _stockOutManager.NoOfRecords();            
            stockOut = new StockOut();
            stockOut.Date = DateTime.Now.ToString("yyyy-MM-dd");
            //stockOut.Date = dateTimePicker.Value.ToString("yyyy-MM-dd");
            int isUpdated = 0;
            foreach (DataGridViewRow row in stockOutDataGridView.Rows)
            {
                history.TableRowNo += 1;
                history.Element = row.Cells["itemNameDataGridViewTextBoxColumn"].Value.ToString();
                stockOut.Quantity = Convert.ToInt32(row.Cells["quantityDataGridViewTextBoxColumn"].Value.ToString());
                stockOut.ItemID = Convert.ToInt32(row.Cells["itemIDDataGridViewTextBoxColumn"].Value.ToString());
                stockOut.Action = action;
                item.ID = stockOut.ItemID;
                dataTable = _stockOutManager.GetItem(item);
                int quantity = Convert.ToInt32(dataTable.Rows[0]["AvailableQuantity"]);
                quantity -= stockOut.Quantity;
                item.AvailableQuantity = quantity;
                _stockOutManager.UpdateItem(item);                
                isUpdated = _stockOutManager.InsertStockOut(stockOut,history);                
            }
            if (isUpdated > 0)
            {
                messageLabel.ForeColor = Color.Green;
                messageLabel.Text = action + " Operation is Done";
            }
            listStockOut = new List<StockOut>();
            stockOutDataGridView.DataSource = null;
            stockOutDataGridView.DataSource = listStockOut;
        }

        private void itemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            item.Name = itemComboBox.Text;
            item.CategoryID = Convert.ToInt32(categoryComboBox.SelectedValue);
            item.CompanyID = Convert.ToInt32(companyComboBox.SelectedValue);
            dataTable = _stockOutManager.GetAvailableQuantityAndReorderLevel(item);
            reorderLevelTextBox.Text = dataTable.Rows[0]["ReorderLevel"].ToString();
            availableQuantityTextBox.Text = dataTable.Rows[0]["AvailableQuantity"].ToString();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuUi menuUi = new MenuUi();
            menuUi.Show();
        }
    }
}
