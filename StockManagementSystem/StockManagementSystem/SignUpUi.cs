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
            UserAccount userAccount = new UserAccount();
            userAccount.Email = emailTextBox.Text;
            userAccount.UserName = userNameTextBox.Text;          
            userAccount.Password = passwordTextBox.Text;
            if(!_signUpManager.IsPasswordUnique(userAccount))
            {
                messageLabel.Text = "Password is Duplicate";
                return;
            }
            if(_signUpManager.IsUserAccountCreated(userAccount))
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
