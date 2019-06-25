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
    public partial class CompanyUi : Form
    {
        CompanyManager _companyManager;
        Company company;
        public CompanyUi()
        {
            InitializeComponent();
            _companyManager = new CompanyManager();
            company = new Company();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string name = "";
            if (SaveButton.Text.Equals("Save"))
            {                
                name = nameTextBox.Text;
                if (String.IsNullOrEmpty(name))
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
            company.Name = name;
            int isExecuted = 0;
            isExecuted = _companyManager.Insert(company);
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
            company.Name = name;
            int isExecuted = 0;
            isExecuted = _companyManager.Update(company);
            if (isExecuted > 0)
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
            companyDataGridView.DataSource = _companyManager.Display();
            foreach (DataGridViewRow row in companyDataGridView.Rows)
                row.Cells["SL"].Value = (row.Index + 1).ToString();
        }

        private void companyDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (companyDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    companyDataGridView.CurrentRow.Selected = true;
                    nameTextBox.Text = companyDataGridView.Rows[e.RowIndex].Cells["NameColumn"].FormattedValue.ToString();
                    company.ID = Convert.ToInt32(companyDataGridView.Rows[e.RowIndex].Cells["IDColumn"].FormattedValue);
                    SaveButton.Text = "Update";

                }
            }catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }

        private void CompanySetup_Load(object sender, EventArgs e)
        {
            Display();
        }
    }
}
