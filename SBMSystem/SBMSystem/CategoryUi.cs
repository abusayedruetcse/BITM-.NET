using SBMSystem.BLL.BLL;
using SBMSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMSystem
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
        private void CategoryUi_Load(object sender, EventArgs e)
        {
            DisplayCategories();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            messageLabel.ForeColor = Color.Red;
            if (String.IsNullOrEmpty(codeTextBox.Text))
            {
                messageLabel.Text = "Enter Code";
                return;
            }
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                messageLabel.Text = "Enter Category Name";
                return;
            }
            category.Name = nameTextBox.Text;
            category.Code = codeTextBox.Text;
            if(SaveButton.Text.Equals("Save"))
            {
                if (_categoryManager.AddCategory(category))
                {
                    messageLabel.ForeColor = Color.Green;
                    messageLabel.Text = "Saved Successfully";
                }
                else
                {                   
                    messageLabel.Text = "Save failed";
                }
            }else
            {
                if(_categoryManager.UpdateCategory(category))
                {
                    messageLabel.ForeColor = Color.Green;
                    messageLabel.Text = "Updated Successfully";
                } 
                else
                {    
                    messageLabel.Text = "Update failed";
                }
                SaveButton.Text = "Save";
            }
            nameTextBox.Text = "";
            codeTextBox.Text = "";
            DisplayCategories();
        }       
        private void DisplayCategories()
        {
            categoryDataGridView.DataSource = _categoryManager.GetCategories();
            for(int i=0;i<categoryDataGridView.Rows.Count-1;i++)
            {
                categoryDataGridView.Rows[i].Cells["SL"].Value = (i + 1).ToString();
                categoryDataGridView.Rows[i].Cells["EditAction"].Value = "Edit";
                categoryDataGridView.Rows[i].Cells["DeleteAction"].Value = "Delete";
            }
        }

        private void categoryDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            messageLabel.Text = "";
            if(categoryDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals("Edit"))
            {
                codeTextBox.Text = categoryDataGridView.Rows[e.RowIndex].Cells["codeDataGridViewTextBoxColumn"].Value.ToString();
                nameTextBox.Text = categoryDataGridView.Rows[e.RowIndex].Cells["nameDataGridViewTextBoxColumn"].Value.ToString();
                SaveButton.Text = "Confirm";
            }
            if (categoryDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals("Delete"))
            {
                category.Code = categoryDataGridView.Rows[e.RowIndex].Cells["codeDataGridViewTextBoxColumn"].Value.ToString();
                if(_categoryManager.DeleteCategory(category))
                {
                    messageLabel.ForeColor = Color.Green;
                    messageLabel.Text = "Deleted Successfully";
                } 
                else
                {
                    messageLabel.ForeColor = Color.Red;
                    messageLabel.Text = "Delete failed";
                }
                DisplayCategories();
            }
        }
    }
}
