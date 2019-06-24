using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomerAccountSystem.Models;
using CustomerAccountSystem.BBL;

namespace CustomerAccountSystem
{
    public partial class SearchUi : Form
    {
        Customer customer;
        SearchManager _searchManager;
        public SearchUi()
        {
            InitializeComponent();
            customer = new Customer();
            _searchManager = new SearchManager();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string accountNo = "";
            accountNo = accountNumberTextBox.Text;
            if(String.IsNullOrEmpty(accountNo))
            {
                messageLabel.Text = "Enter account Number";
                return;
            }
            if(accountNo.Length<8)
            {
                messageLabel.Text = "Enter at least 8 characters Account No.";
                return;
            }
            customer.AccountNo = accountNo;
            //ShowCustomer
            DataTable dataTable = _searchManager.ShowCustomer(customer);
            if(dataTable.Rows.Count==0)
            {
                messageLabel.Text = "Not Found This Account";
                return;
            }
            displayDataGridView.DataSource = dataTable;
        }
    }
}
