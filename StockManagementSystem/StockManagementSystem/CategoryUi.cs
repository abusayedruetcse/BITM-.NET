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
    public partial class CategoryUi : Form
    {                       
        Category category;
        CategoryManager _categoryManager;
        public CategoryUi()
        {
            InitializeComponent();            
            category = new Category();
            _categoryManager = new CategoryManager();
        }
        private void CategorySetup_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {           
            string name = "";
            if (SaveButton.Text.Equals("Save"))
            {               
                name = nameTextBox.Text;
                if(String.IsNullOrEmpty(name))
                {
                    messageLabel.Text = "Name Field is Empty";
                    return;
                }               
                Insert(name);                
            }
            else
            {
                name = nameTextBox.Text;
                if (String.IsNullOrEmpty(name))
                {
                    messageLabel.Text = "Name Field is Empty";
                    return;
                }               
                Update(name);
                SaveButton.Text = "Save";
            }
            nameTextBox.Text = "";
            Display();
        }
        private void Insert(string name)
        {
            category.Name = name;
            int isExecuted = 0;
            isExecuted = _categoryManager.Insert(category);
            if (isExecuted > 0)
            {
                messageLabel.Text = "Saved Successfully";
            }
            else
            {
                messageLabel.Text = "Save Failed!";
            }            
        }
        private void Update(string name)
        {
            category.Name = name;
            int isExecuted = 0;
            isExecuted = _categoryManager.Update(category);
            if(isExecuted>0)
            {
                messageLabel.Text = "Updated Successfully";
            }
            else
            {
                messageLabel.Text = "Update Failed!";
            }
        }        
        private void Display()
        {            
            categoryDataGridView.DataSource = _categoryManager.Display();
            foreach (DataGridViewRow row in categoryDataGridView.Rows)
                row.Cells["SL"].Value = (row.Index + 1).ToString();
            categoryDataGridView.RowHeadersVisible = false;

        }

        private void categoryDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(categoryDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                categoryDataGridView.CurrentRow.Selected = true;
                nameTextBox.Text = categoryDataGridView.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn1"].FormattedValue.ToString();
                category.ID = Convert.ToInt32(categoryDataGridView.Rows[e.RowIndex].Cells["iDDataGridViewTextBoxColumn"].FormattedValue);
                SaveButton.Text = "Update";

            }
        }

        
    }
}
