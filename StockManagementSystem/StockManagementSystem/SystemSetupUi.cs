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

namespace StockManagementSystem
{
    public partial class SystemSetupUi : Form
    {
        public SystemSetupUi()
        {
            InitializeComponent();
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            SMSDBScript.ServerName = serverNameTextBox.Text;
            SMSDBScript.DatabaseName = databaseNameTextBox.Text;
            if(newDBRadioButton.Checked)
            {
                MessageBox.Show("Create Database as named Like this new Database Name first before click ok");
                SMSDBScript.Execute();
                SMSDBScript.IscreatedDB = true;
            }

            this.Hide();
            FrontUi frontUi = new FrontUi();
            frontUi.Show();
        }
    }
}
