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
    public partial class LoginUi : Form
    {
        LogInManager _logInManager;
        public LoginUi()
        {
            InitializeComponent();
            _logInManager = new LogInManager();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrontUi front = new FrontUi();
            front.Show();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            UserAccount userAccount = new UserAccount();
            userAccount.Email = userNameTextBox.Text;
            userAccount.UserName = userNameTextBox.Text;
            userAccount.Password = passwordTextBox.Text;
            if(_logInManager.IsUserValid(userAccount))
            {
                this.Hide();
                MenuUi menuUi = new MenuUi();
                menuUi.Show();
            }
            else
            {
                messageLabel.Text = "Invaid User Name/ Email OR Password";
                return;
            }
           
        }
    }
}
