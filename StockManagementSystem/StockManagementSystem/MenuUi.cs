using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystem
{
    public partial class MenuUi : Form
    {
        public MenuUi()
        {
            InitializeComponent();
        }        

        private void categorySetupLabel_Click(object sender, EventArgs e)
        {
            
            //this.Hide();
            CategoryUi categoryUi = new CategoryUi();
            categoryUi.Show();
        }

        private void companySetupLabel_Click(object sender, EventArgs e)
        {
            //this.Hide();
            CompanyUi companyUi = new CompanyUi();
            companyUi.Show();
        }

        private void itemSetupLabel_Click(object sender, EventArgs e)
        {
            //this.Hide();
            ItemUi itemUi = new ItemUi();
            itemUi.Show();            
        }

        private void stockInLabel_Click(object sender, EventArgs e)
        {
            //this.Hide();
            StockInUi stockInUi = new StockInUi();
            stockInUi.Show();
            
        }

        private void stockOutLabel_Click(object sender, EventArgs e)
        {
            //this.Hide();
            StockOutUi stockOutUi = new StockOutUi();
            stockOutUi.Show();           
        }

        private void searchLabel_Click(object sender, EventArgs e)
        {
            //this.Hide();
            SearchUi searchUi = new SearchUi();
            searchUi.Show();
            
        }

        private void viewLabel_Click(object sender, EventArgs e)
        {
            //this.Hide();
            ViewUi viewUi = new ViewUi();
            viewUi.Show();
        }
    }
}
