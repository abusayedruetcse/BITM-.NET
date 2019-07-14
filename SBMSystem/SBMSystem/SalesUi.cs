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
        double grandTotal = 0;
        double discountPercentage = 0;
        double discountAmount = 0;
        double payableAmount = 0;
        public SalesUi()
        {
            InitializeComponent();
            _salesManager = new SalesManager();
            listOfSales = new List<Sales>();            
        }
        private void SalesUi_Load(object sender, EventArgs e)
        {
            customerComboBox.DataSource = _salesManager.LoadCustomerToComboBox();
            productComboBox.DataSource = _salesManager.LoadProductToComboBox();
            loyaltyPointTextBox.Text = "<View>";
            customerComboBox.Text = "-Select-";
            productComboBox.Text = "-Select-";
            availableQuantityTextBox.Text = "<View>";
            unitPriceTextBox.Text = "";
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
            addMessageLabel.Text = "";
            saveMessageLabel.Text = "";
            addMessageLabel.ForeColor = Color.Red;
            try
            {
                if (customerComboBox.Text.Equals("-Select-"))
                {
                    addMessageLabel.Text = "Select a customer";
                    return;
                }
                if(String.IsNullOrEmpty(dateTextBox.Text))
                {
                    addMessageLabel.Text = "Enter date";
                    return;
                }
                if (productComboBox.Text.Equals("-Select-"))
                {
                    addMessageLabel.Text = "Select a Product";
                    return;
                }
                if (String.IsNullOrEmpty(quantityTextBox.Text))
                {
                    addMessageLabel.Text = "Enter quantity";
                    return;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(quantityTextBox.Text, "[^0-9]"))
                {
                    addMessageLabel.Text = "Enter Numeric quantity value";
                    return;
                }
                if (String.IsNullOrEmpty(unitPriceTextBox.Text))
                {
                    addMessageLabel.Text = "Enter unit price";
                    return;
                }
                sales = new Sales();
                sales.CustomerCode = customerComboBox.SelectedValue.ToString();
                sales.Date = dateTextBox.Text;
                sales.ProductCode = productComboBox.SelectedValue.ToString();
                sales.Quantity = Convert.ToInt32(quantityTextBox.Text);
                sales.UnitPrice = Convert.ToDouble(unitPriceTextBox.Text);
                sales.SL = listOfSales.Count + 1;
                sales.Product = productComboBox.Text;
                sales.TotalPrice = (Double)sales.Quantity * sales.UnitPrice;
                grandTotal += sales.TotalPrice;
                discountPercentage = Convert.ToDouble(loyaltyPointTextBox.Text) / 10;
                sales.PayableAmount = sales.TotalPrice - (sales.TotalPrice * discountPercentage / 100);
                discountAmount += sales.TotalPrice * discountPercentage / 100;
                payableAmount += sales.PayableAmount;
            }catch(Exception exception)
            {
                addMessageLabel.Text = exception.Message;
                return;
            }
            listOfSales.Add(sales);
            addMessageLabel.ForeColor = Color.Green;
            addMessageLabel.Text = "Added Successfully";
            Display();
            
        } 
        private void Display()
        {
            productComboBox.Text = "-Select-";
            availableQuantityTextBox.Text = "<View>";
            quantityTextBox.Text = "";
            unitPriceTextBox.Text = "";
            grandTotalTextBox.Text = grandTotal.ToString();
            discountPercentTextBox.Text = discountPercentage.ToString();
            discountAmountTextBox.Text = discountAmount.ToString();
            payableAmountTextBox.Text = payableAmount.ToString();
            salesDataGridView.DataSource = null;
            salesDataGridView.DataSource = listOfSales;
        }

        private void salesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            addMessageLabel.Text = "";
            saveMessageLabel.Text = "";
            addMessageLabel.ForeColor = Color.Red;
            try
            {
                if (salesDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals("Delete"))
                {
                    int index = Convert.ToInt32(salesDataGridView.Rows[e.RowIndex].Cells["sLDataGridViewTextBoxColumn"].Value);
                    grandTotal -= listOfSales[index - 1].TotalPrice;
                    discountAmount -= listOfSales[index - 1].TotalPrice * discountPercentage / 100;
                    payableAmount -= listOfSales[index - 1].PayableAmount;
                    listOfSales.RemoveAt(index - 1);
                    addMessageLabel.ForeColor = Color.Green;
                    addMessageLabel.Text = "Deleted Successfully";
                    for (int i = 0; i < listOfSales.Count; i++)
                    {
                        listOfSales[i].SL = i + 1;
                    }
                    Display();
                }
            }
            catch(Exception exception)
            {
                addMessageLabel.Text = exception.Message;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            addMessageLabel.Text = "";
            saveMessageLabel.Text = "";
            saveMessageLabel.ForeColor = Color.Red;
            if (listOfSales.Count==0)
            {
                saveMessageLabel.Text = "Sales item is empty";
                return;
            }
            for(int i=0;i<listOfSales.Count;i++)
            {
                listOfSales[i].Date = Convert.ToDateTime(listOfSales[i].Date).ToString("yyyy-MM-dd");
                _salesManager.AddSales(listOfSales[i]);
            }
            saveMessageLabel.ForeColor = Color.Green;
            saveMessageLabel.Text = "Save Successfully";
            listOfSales = new List<Sales>();
            dateTextBox.Text = "";
            loyaltyPointTextBox.Text = "<View>";
            customerComboBox.Text = "-Select-";            
            Display();
            grandTotalTextBox.Text = "<View>";
            discountPercentTextBox.Text = "";
            discountAmountTextBox.Text = "";
            payableAmountTextBox.Text = "";
        }

        
    }
}
