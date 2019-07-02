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
    public partial class ViewUi : Form
    {
        DataTable dataTable;
        ViewManager _viewManager;
        public ViewUi()
        {
            InitializeComponent();
            dataTable = new DataTable();
            _viewManager = new ViewManager();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string fromDate = fromDateTimePicker.Value.ToString("yyyy-MM-dd");
            string toDate = toDateTimePicker.Value.ToString("yyyy-MM-dd");
            string action="";
            if(soldRadioButton.Checked==true)
            {
                action = "Sell";
            }else if(damagedRadioButton.Checked==true)
            {
                action = "Damage";
            }else
            {
                action = "Lost";
            }
            dataTable = _viewManager.LoadStockOutToDataGridView(fromDate, toDate, action);
            viewReportDataGridView.DataSource = dataTable;
            foreach(DataGridViewRow row in viewReportDataGridView.Rows)
            {
                row.Cells["SL"].Value = (row.Index + 1).ToString();
            }
            if(dataTable.Rows.Count==0)
            {
                MessageBox.Show("No Data Found");
            }
        }
    }
}
