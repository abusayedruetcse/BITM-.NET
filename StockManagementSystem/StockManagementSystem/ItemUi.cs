using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystem.Models;
using StockManagementSystem.BLL;

namespace StockManagementSystem
{
    public partial class ItemUi : Form
    {       
        Item item;
        ItemManager _itemManager;
        public ItemUi()
        {
            InitializeComponent();          
            item = new Item();
            _itemManager = new ItemManager();
        }

        private void categoryComboBox_Click(object sender, EventArgs e)
        {
            categoryComboBox.DataSource = _itemManager.ComboxBoxWithSelect("Categories");            
        }

        private void companyComboBox_Click(object sender, EventArgs e)
        {
            companyComboBox.DataSource = _itemManager.ComboxBoxWithSelect("Companies");            
        }
       
        private void SaveButton_Click(object sender, EventArgs e)
        {   
            if(String.IsNullOrEmpty(categoryComboBox.Text))
            {
                messageLabel.Text = "Select Category First";
                return;
            }
            item.CategoryID = Convert.ToInt32(categoryComboBox.SelectedValue);
            if (String.IsNullOrEmpty(companyComboBox.Text))
            {
                messageLabel.Text = "Select Company First";
                return;
            }
            item.CompanyID = Convert.ToInt32(companyComboBox.SelectedValue);
            if(String.IsNullOrEmpty(itemNameTextBox.Text))
            {
                messageLabel.Text = "Enter Item ";
                return;
            }
            item.Name = itemNameTextBox.Text;            
            if(_itemManager.IsDuplicate(item))
            {
                messageLabel.Text = "Item is Duplicate!";
                return;
            }
            if (String.IsNullOrEmpty(reorderLevelTextBox.Text))
            {
                messageLabel.Text = "Enter Reorder Level ";
                return;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(reorderLevelTextBox.Text, "[^0-9]"))
            {
                messageLabel.Text = "Enter Only Digits";
                return;
            }
            item.ReorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);

            Insert(item);
            //cleaning
            categoryComboBox.Text = "";
            companyComboBox.Text = "";
            itemNameTextBox.Text = "";
            reorderLevelTextBox.Text = "";
        }       
       
        private void Insert(Item item)
        {
            int isExecuted = 0;
            isExecuted = _itemManager.Insert(item);
            if (isExecuted > 0)
            {
                messageLabel.Text = "Saved Successfully";
            }
            else
            {
                messageLabel.Text = "Save Failed!";
            }           
        }
    }
}
