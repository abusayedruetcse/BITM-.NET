using SBMSystem.BLL.BLL;
using SBMSystem.Models.Models;
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
    public partial class SalesUi : Form
    {
        SalesManager _salesManager;
        bool isCustomerAdded = false;
        Customer customer;
        Product product;
        List<Sales> listOfSales;
        Sales sales;
        public SalesUi()
        {
            InitializeComponent();
            _salesManager = new SalesManager();
            listOfSales = new List<Sales>();
            customerComboBox.DataSource = _salesManager.LoadCustomerToComboBox();
            productComboBox.DataSource = _salesManager.LoadProductToComboBox();
            loyaltyPointTextBox.Text = "<View>";
            customerComboBox.Text = "-Select-";
            productComboBox.Text = "-Select-";
            availableQuantityTextBox.Text = "<View>";
        }
        private void customerComboBox_Click(object sender, EventArgs e)
        {
            if(isCustomerAdded)
            {
                customerComboBox.DataSource = _salesManager.LoadCustomerToComboBox();
                isCustomerAdded = false;
            }
        }
        private void CustomerAddButton_Click(object sender, EventArgs e)
        {
            CustomerUi customerUi = new CustomerUi();
            customerUi.Show();
            isCustomerAdded = true;
        }
        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            customer = new Customer();
            customer.Code = customerComboBox.SelectedValue.ToString();
            loyaltyPointTextBox.Text = _salesManager.GetLoyaltyPoint(customer).ToString();
        }

        private void productComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            product = new Product();
            product.Code = productComboBox.SelectedValue.ToString();
            DataTable dataTable = _salesManager.GetAvailableQuantityAndUnitPrice(product);
            if(dataTable.Rows.Count>0)
            {
                availableQuantityTextBox.Text = dataTable.Rows[0]["AvailableQuantity"].ToString();
                unitPriceTextBox.Text= dataTable.Rows[0]["UnitPrice"].ToString();
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            sales = new Sales();
            sales.CustomerCode = customerComboBox.SelectedValue.ToString();
            sales.Date = dateTextBox.Text;
            sales.ProductCode = productComboBox.SelectedValue.ToString();
            sales.Quantity = Convert.ToInt32(quantityTextBox.Text);
            sales.UnitPrice = Convert.ToInt32(unitPriceTextBox.Text);
            sales.SL = listOfSales.Count + 1;
            sales.Product = productComboBox.Text;
            sales.TotalPrice = sales.Quantity * sales.UnitPrice;
            listOfSales.Add(sales);
            Display();
        } 
        private void Display()
        {
            salesDataGridView.DataSource = null;
            salesDataGridView.DataSource = listOfSales;
        }

        private void salesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(salesDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals("Delete"))
            {
                int index = Convert.ToInt32(salesDataGridView.Rows[e.RowIndex].Cells["sLDataGridViewTextBoxColumn"].Value);
                listOfSales.RemoveAt(index - 1);
                for (int i = 0; i < listOfSales.Count; i++)
                {
                    listOfSales[i].SL = i + 1;
                }
                Display();
            }
        }
    }
}
