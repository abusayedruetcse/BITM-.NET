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
    public partial class EntryUi : Form
    {
        Customer customer;
        Account account;
        EntryManager _entryManager;
        public EntryUi()
        {
            InitializeComponent();
            customer = new Customer();
            account = new Account();
            _entryManager = new EntryManager();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            customer.Name = customerNameTextBox.Text;
            customer.Email = emailTextBox.Text;
            if(accountNumberTextBox.Text.Length<8)
            {
                messageLabel.Text = "Enter at least 8 characters long Account no.";
                return;
            }
            customer.AccountNo = accountNumberTextBox.Text;
            if (_entryManager.IsAccountNoDuplicate(customer)) //IsAccountNoDuplicate
            {
                messageLabel.Text = "AccountNo is Duplicate, Enter Unique!";
                return;
            }
            //customer.AccountNo = accountNumberTextBox.Text;           
            customer.OpeningDate = openingDateTextBox.Text;

            //InsertEntry
            int isExecuted = 0;
            isExecuted = _entryManager.InsertEntry(customer);
            if(isExecuted>0)
            {
                messageLabel.Text = "Saved Entity";
            }
            else
            {
                messageLabel.Text = "Save Failed";
            }
            //by default set amount=0
            account.AccountNo = customer.AccountNo;
            account.Amount = 0;
            _entryManager.InsertAmount(account);
        }
    }
}
