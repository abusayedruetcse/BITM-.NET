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
using System.Data;

namespace StockManagementSystem
{
    public partial class CategoryUi : Form
    {                       
        Category category;
        CategoryManager _categoryManager;
        History history;
        DataTable dataTable;
        public CategoryUi()
        {
            InitializeComponent();            
            category = new Category();
            _categoryManager = new CategoryManager();
            history = new History();
            dataTable = new DataTable();
        }
        private void CategorySetup_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {           
            history.UserID = UserAccount.ID;
            history.TableName = "Categories";       
            history.DateAndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string name = "";
            name = nameTextBox.Text;
            if (String.IsNullOrEmpty(name))
            {
                messageLabel.ForeColor = Color.Red;
                messageLabel.Text = "Category Name Field is Empty";
                return;
            }
            category.Name = name;           
            history.Element = name;
            if (SaveButton.Text.Equals("Save"))
            {
                if (_categoryManager.IsCategoryDuplicate(category))
                {
                    messageLabel.ForeColor = Color.Red;
                    messageLabel.Text = "Category is Duplicate";
                    return;
                }
                Insert(name);                
            }
            else   //Update
            {
                dataTable = _categoryManager.IsUpdateCategoryDuplicate(category);
                if (dataTable.Rows.Count>0)
                {
                    if(Convert.ToInt32(dataTable.Rows[0]["ID"]) == category.ID)
                    {
                        messageLabel.ForeColor = Color.Green;
                        messageLabel.Text = "Category is Unchanged";
                    }
                    else
                    {
                        messageLabel.ForeColor = Color.Red;
                        messageLabel.Text = "Category is Duplicate";
                    }                                      
                    return;
                }
                history.TableRowNo = category.ID;
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
            isExecuted = _categoryManager.Insert(category, history);
            if (isExecuted > 0)
            {
                messageLabel.ForeColor = Color.Green;
                messageLabel.Text = "Saved Successfully";
            }
            else
            {
                messageLabel.ForeColor = Color.Red;
                messageLabel.Text = "Save Failed!";
            }            
        }
        private void Update(string name)
        {
            category.Name = name;
            int isExecuted = 0;
            isExecuted = _categoryManager.Update(category, history);
            if(isExecuted>0)
            {
                messageLabel.ForeColor = Color.Green;
                messageLabel.Text = "Updated Successfully";
            }
            else
            {
                messageLabel.ForeColor = Color.Red;
                messageLabel.Text = "Update Failed!";
            }
        }        
        private void Display()
        {            
            categoryDataGridView.DataSource = _categoryManager.Display();
            foreach (DataGridViewRow row in categoryDataGridView.Rows)
                row.Cells["SL"].Value = (row.Index + 1).ToString();
            history.TableRowNo = categoryDataGridView.Rows.Count + 1;

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

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuUi menuUi = new MenuUi();
            menuUi.Show();

        }
    }
}
