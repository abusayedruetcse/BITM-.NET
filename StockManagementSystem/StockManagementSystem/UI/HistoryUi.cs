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
    public partial class HistoryUi : Form
    {
        HistoryManagement _historyManagement;
        public HistoryUi()
        {
            InitializeComponent();
            _historyManagement = new HistoryManagement();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuUi menuUi = new MenuUi();
            menuUi.Show();
        }

        private void categorySetupLabel_Click(object sender, EventArgs e)
        {
            historyDataGridView.DataSource = _historyManagement.LoadCategoryCompanyItemHistory("Categories");
            display();
        }

        private void companySetupLabel_Click(object sender, EventArgs e)
        {
            historyDataGridView.DataSource = _historyManagement.LoadCategoryCompanyItemHistory("Companies");
            display();
        }

        private void itemSetupLabel_Click(object sender, EventArgs e)
        {
            historyDataGridView.DataSource = _historyManagement.LoadCategoryCompanyItemHistory("Items");
            display();
        }

        private void stockInLabel_Click(object sender, EventArgs e)
        {
            historyDataGridView.DataSource = _historyManagement.LoadStockInOutHistory("StockIns");
            display();
        }

        private void stockOutLabel_Click(object sender, EventArgs e)
        {
            historyDataGridView.DataSource = _historyManagement.LoadStockInOutHistory("StockOuts");
            display();
        } 
        private void display()
        {
            //foreach(DataGridViewRow row in historyDataGridView.Rows)
            //{
            //    row.Cells["SL"].Value = (row.Index + 1).ToString();
            //    row.Cells["dateAndTimeDataGridViewTextBoxColumn"].Value = Convert.ToDateTime(row.Cells["dateAndTimeDataGridViewTextBoxColumn"].Value).ToString("dd-MM-yyyy HH:mm:ss");
            //}
            for(int i=0;i<historyDataGridView.Rows.Count-1;i++)
            {
                historyDataGridView.Rows[i].Cells["SL"].Value = (i + 1).ToString();
                historyDataGridView.Rows[i].Cells["dateAndTimeDataGridViewTextBoxColumn"].Value = Convert.ToDateTime(historyDataGridView.Rows[i].Cells["dateAndTimeDataGridViewTextBoxColumn"].Value).ToString("dd-MM-yyyy HH:mm:ss");
            }
        }
    }
}
