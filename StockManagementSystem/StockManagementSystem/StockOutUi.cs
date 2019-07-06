using System;
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
        public StockOutUi()
        {
            InitializeComponent();
            _stockOutManager = new StockOutManager();
            item = new Item();
            listStockOut = new List<StockOut>();
            
        }

        private void StockOutUi_Load(object sender, EventArgs e)
        {
            //Preview 
            companyComboBox.Text = "-Select-";
            categoryComboBox.Text = "-Select-";
            itemComboBox.Text = "-Select-";
            reorderLevelTextBox.Text = "<View>";
            availableQuantityTextBox.Text = "<View>";
        }

        private void companyComboBox_Click(object sender, EventArgs e)
        {
            //if (categoryComboBox.Text.Equals("-Select-") || categoryComboBox.Text == null)
            //{
                messageLabel.Text = "";
                dataTable = _stockOutManager.LoadCompanyToComboBox();
                companyComboBox.DataSource = dataTable;
                if(dataTable.Rows.Count==0)
                {
                    messageLabel.Text = "No company in Database";
                    return;
                }
            //} 
            //else
            //{
            //    dataTable = _stockOutManager.LoadFilteredCompanyToComboBox(Convert.ToInt32(categoryComboBox.SelectedValue));
            //    companyComboBox.DataSource = dataTable;
            //    if (dataTable.Rows.Count == 0)
            //    {
            //        messageLabel.Text = "No company with this Category in Database";
            //        companyComboBox.Text = "<--Company Empty-->";
            //        return;
            //    }
            //}
        }

        private void categoryComboBox_Click(object sender, EventArgs e)
        {
            //if (companyComboBox.Text.Equals("-Select-") || companyComboBox.Text == "")
            //{
                messageLabel.Text = "";
                dataTable = _stockOutManager.LoadCategoryToComboBox();
                categoryComboBox.DataSource = dataTable;
                if (dataTable.Rows.Count == 0)
                {
                    messageLabel.Text = "No category in Database";
                    return;
                }
            //}
            //else
            //{
            //    dataTable = _stockOutManager.LoadFilteredCategoryToComboBox(Convert.ToInt32(companyComboBox.SelectedValue));
            //    categoryComboBox.DataSource = dataTable;
            //    if (dataTable.Rows.Count == 0)
            //    {
            //        messageLabel.Text = "No category with this company in Database";
            //        categoryComboBox.Text = "<--Category Empty-->";
            //        return;
            //    }
            //}
        }

        private void itemComboBox_Click(object sender, EventArgs e)
        {
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
                itemComboBox.Text = "";
                return;
            }            
        }      
        
        private void AddButton_Click(object sender, EventArgs e)
        {
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
                messageLabel.Text = "Select Category";
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
            stockOut = new StockOut();
            stockOut.Date = dateTimePicker.Value.ToString("yyyy-MM-dd");
            foreach (DataGridViewRow row in stockOutDataGridView.Rows)
            {

                stockOut.Quantity = Convert.ToInt32(row.Cells["quantityDataGridViewTextBoxColumn"].Value.ToString());
                stockOut.ItemID = Convert.ToInt32(row.Cells["itemIDDataGridViewTextBoxColumn"].Value.ToString());
                stockOut.Action = action;
                item.ID = stockOut.ItemID;
                dataTable = _stockOutManager.GetItem(item);
                int quantity = Convert.ToInt32(dataTable.Rows[0]["AvailableQuantity"]);
                quantity -= stockOut.Quantity;
                item.AvailableQuantity = quantity;
                _stockOutManager.UpdateItem(item);
                int isUpdated = 0;
                isUpdated = _stockOutManager.InsertStockOut(stockOut);
                if (isUpdated > 0)
                {
                    messageLabel.Text = "Item: " + itemComboBox.Text + " Saved";
                }
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
