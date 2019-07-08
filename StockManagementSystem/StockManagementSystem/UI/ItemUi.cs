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
        History history;
        public ItemUi()
        {
            InitializeComponent();          
            item = new Item();
            _itemManager = new ItemManager();
            history = new History();
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
            //validation checking
            messageLabel.ForeColor = Color.Red;
            if(String.IsNullOrEmpty(categoryComboBox.Text))
            {
                messageLabel.Text = "Select Category First";
                return;
            }            
            if (String.IsNullOrEmpty(companyComboBox.Text))
            {
                messageLabel.Text = "Select Company First";
                return;
            }           
            if(String.IsNullOrEmpty(itemNameTextBox.Text))
            {
                messageLabel.Text = "Enter Item ";
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
            //assign values
            item.CategoryID = Convert.ToInt32(categoryComboBox.SelectedValue);
            item.CompanyID = Convert.ToInt32(companyComboBox.SelectedValue);
            item.Name = itemNameTextBox.Text;            
            if(_itemManager.IsDuplicate(item))
            {
                messageLabel.Text = "Item is Duplicate!";
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
            history.UserID = UserAccount.ID;
            history.TableName = "Items";
            history.TableRowNo = _itemManager.NoOfItem() + 1;
            history.DateAndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            history.Element = item.Name;
            int isExecuted = 0;
            isExecuted = _itemManager.Insert(item,history);
            if (isExecuted > 0)
            {
                messageLabel.ForeColor = Color.Green;
                messageLabel.Text = "Saved Successfully";              
            }
            else
            {
                messageLabel.ForeColor = Color.Green;
                messageLabel.Text = "Save Failed!";
            }           
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuUi menuUi = new MenuUi();
            menuUi.Show();
        }
    }
}
