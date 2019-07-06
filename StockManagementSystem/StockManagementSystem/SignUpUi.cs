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
    public partial class SignUpUi : Form
    {
        SignUpManager _signUpManager;
        public SignUpUi()
        {
            InitializeComponent();
            _signUpManager = new SignUpManager();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrontUi front = new FrontUi();
            front.Show();
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            UserAccount.Email = emailTextBox.Text;
            UserAccount.UserName = userNameTextBox.Text;          
            UserAccount.Password = passwordTextBox.Text;
            if(!_signUpManager.IsPasswordUnique())
            {
                messageLabel.Text = "Password is Duplicate";
                return;
            }
            if(_signUpManager.IsUserAccountCreated())
            {
                this.Hide();
                LoginUi loginUi = new LoginUi();
                loginUi.Show();
            } 
            else
            {
                messageLabel.Text = "Not Created";
            }
        }
    }
}
