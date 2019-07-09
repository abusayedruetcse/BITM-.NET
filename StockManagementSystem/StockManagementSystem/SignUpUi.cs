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
using System.ComponentModel.DataAnnotations;

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
            messageLabel.Text = "";
            if(String.IsNullOrEmpty(emailTextBox.Text))
            {
                messageLabel.Text = "Enter an Email";
                return;
            }
            if(String.IsNullOrEmpty(userNameTextBox.Text))
            {
                messageLabel.Text = "Enter a user name";
                return;
            }
            if(String.IsNullOrEmpty(passwordTextBox.Text))
            {
                messageLabel.Text = "Enter a password";
                return;
            }
            UserAccount.Email = emailTextBox.Text;
            UserAccount.UserName = userNameTextBox.Text;
            UserAccount.Password = passwordTextBox.Text;
            if (!new EmailAddressAttribute().IsValid(emailTextBox.Text))
            {
                messageLabel.Text = "Invalid Email Address";
                return;
            }
            if(_signUpManager.IsEmailUsed())
            {
                messageLabel.Text = "Already this email has been used";
                return;
            } 
            if(_signUpManager.IsUserNameUsed())
            {
                messageLabel.Text = "Enter different user name";
                return;
            }
            if (!confirmPasswordTextBox.Text.Equals(passwordTextBox.Text))
            {
                messageLabel.Text = "Password does not match";
                confirmPasswordTextBox.Text = "";
                passwordTextBox.Text = "";
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
