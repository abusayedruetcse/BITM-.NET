using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMSystem
{
    public partial class MenuListUi : Form
    {
        public MenuListUi()
        {
            InitializeComponent();
        }

        private void categoryLabel_Click(object sender, EventArgs e)
        {
            CategoryUi categoryUi = new CategoryUi();
            categoryUi.Show();
        }

        private void productLabel_Click(object sender, EventArgs e)
        {
            ProductUi productUi = new ProductUi();
            productUi.Show();
        }

        private void customerLabel_Click(object sender, EventArgs e)
        {
            CustomerUi customerUi = new CustomerUi();
            customerUi.Show();
        }

        private void SupplierLabel_Click(object sender, EventArgs e)
        {
            SupplierUi supplierUi = new SupplierUi();
            supplierUi.Show();
        }

        private void purchaseLabel_Click(object sender, EventArgs e)
        {
            PurchaseUi purchaseUi = new PurchaseUi();
            purchaseUi.Show();
        }

        private void salesLabel_Click(object sender, EventArgs e)
        {
            SalesUi salesUi = new SalesUi();
            salesUi.Show();
        }
    }
}
