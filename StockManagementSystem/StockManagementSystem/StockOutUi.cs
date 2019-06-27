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
        public StockOutUi()
        {
            InitializeComponent();
            _stockOutManager = new StockOutManager();
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
            if (categoryComboBox.Text.Equals("-Select-") || categoryComboBox.Text == null)
            {
                dataTable = _stockOutManager.LoadCompanyToComboBox();
                companyComboBox.DataSource = dataTable;
                if(dataTable.Rows.Count==0)
                {
                    messageLabel.Text = "No company in Database";
                    return;
                }
            } 
            else
            {
                dataTable = _stockOutManager.LoadFilteredCompanyToComboBox(Convert.ToInt32(categoryComboBox.SelectedValue));
                companyComboBox.DataSource = dataTable;
                if (dataTable.Rows.Count == 0)
                {
                    messageLabel.Text = "No company with this Category in Database";
                    companyComboBox.Text = "<--Company Empty-->";
                    return;
                }
            }
        }

        private void categoryComboBox_Click(object sender, EventArgs e)
        {
            if (companyComboBox.Text.Equals("-Select-") || companyComboBox.Text == null)
            {
                dataTable = _stockOutManager.LoadCategoryToComboBox();
                categoryComboBox.DataSource = dataTable;
                if (dataTable.Rows.Count == 0)
                {
                    messageLabel.Text = "No category in Database";
                    return;
                }
            }
            else
            {
                dataTable = _stockOutManager.LoadFilteredCategoryToComboBox(Convert.ToInt32(companyComboBox.SelectedValue));
                categoryComboBox.DataSource = dataTable;
                if (dataTable.Rows.Count == 0)
                {
                    messageLabel.Text = "No category with this company in Database";
                    categoryComboBox.Text = "<--Category Empty-->";
                    return;
                }
            }
        }
    }
}
