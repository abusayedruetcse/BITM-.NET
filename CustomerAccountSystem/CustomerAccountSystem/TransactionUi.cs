using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomerAccountSystem.BBL;
using CustomerAccountSystem.Models;
namespace CustomerAccountSystem
{
    public partial class TransactionUi : Form
    {
        Account account;
        TransactionManager _transactionManager;

        public TransactionUi()
        {
            InitializeComponent();
            _transactionManager = new TransactionManager();
            account = new Account();
        }

        private void DepositeButton_Click(object sender, EventArgs e)
        {
            Action("+");
        }

        private void WithdrawButton_Click(object sender, EventArgs e)
        {
            Action("-");
        }
        private void Action(string action)
        {
            try
            {
                messageLabel.Text = "";
                if (String.IsNullOrEmpty(amountTextBox.Text))
                {
                    messageLabel.Text = "Enter amount";
                    return;
                }
                if (String.IsNullOrEmpty(accountNumberTextBox.Text))
                {
                    messageLabel.Text = "Enter a Account Number!";
                    return;
                }
                if (accountNumberTextBox.Text.Length < 8)
                {
                    messageLabel.Text = "Enter at least 8 characters Account Number";
                    return;
                }
                account.AccountNo = accountNumberTextBox.Text;                
                DataTable dataTable = _transactionManager.GetAmount(account);
                if (dataTable.Rows.Count==0)
                {
                    messageLabel.Text = "Invalid Account Number!";
                    return;
                }
                double amount = Convert.ToDouble(dataTable.Rows[0]["Amount"]);
                account.Amount = Convert.ToDouble(amountTextBox.Text);
                if (action.Equals("+"))
                {                   
                    amount += account.Amount;
                }
                if (action.Equals("-"))
                {
                    amount -= account.Amount;
                }
                account.Amount = amount;

                int isExecuted = 0;
                isExecuted = _transactionManager.UpdateAccount(account);
                if (isExecuted > 0)
                {
                    messageLabel.Text = "Successfully Updated";
                }
                else
                {
                    messageLabel.Text = "Update Failed";
                }
            }catch(Exception exception)
            {
                messageLabel.Text = exception.Message;
            }
        }
    }
}
