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
    public partial class PurchaseUi : Form
    {
        Purchase purchase;
        List<Purchase> listOfPurchase;
        PurchaseManager _purchaseManager;
        int index = 0;
        bool isSupplierAdded = false;
        Product product;
        public PurchaseUi()
        {
            InitializeComponent();            
            listOfPurchase = new List<Purchase>();
            _purchaseManager = new PurchaseManager();
        }
        private void PurchaseUi_Load(object sender, EventArgs e)
        {
            supplierComboBox.DataSource = _purchaseManager.LoadSupplierToComboBox();
            productsComboBox.DataSource = _purchaseManager.LoadProductToComboBox();
            supplierComboBox.Text = "-Select-";
            productsComboBox.Text = "-Select-";
            codeTextBox.Text = "<View>";
            totalPriceTextBox.Text = "<View>";
            previousCostPriceTextBox.Text = "<View>";
            previousMRPTextBox.Text = "<View>";
        }
        private void productsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            codeTextBox.Text = productsComboBox.SelectedValue.ToString();
            Product product = new Product();
            product.Code = codeTextBox.Text;
            DataTable dataTable = _purchaseManager.GetProductByCode(product);
            if(dataTable.Rows.Count>0)
            {
                previousCostPriceTextBox.Text = dataTable.Rows[0]["UnitPrice"].ToString();
                previousMRPTextBox.Text = dataTable.Rows[0]["CurrentMRP"].ToString();
            }
        }
        private void unitPriceTextBox_TextChanged(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            if (String.IsNullOrEmpty(unitPriceTextBox.Text))
            {
                messageLabel.Text = "Enter Unit Price";
                return;
            }
            if (String.IsNullOrEmpty(quantityTextBox.Text))
            {
                messageLabel.Text = "Enter Quantity";
                return;
            }
            totalPriceTextBox.Text = (Convert.ToInt32(quantityTextBox.Text) * Convert.ToInt32(unitPriceTextBox.Text)).ToString();
            newMRPTextBox.Text = (Convert.ToInt32(Convert.ToDouble(unitPriceTextBox.Text) * 1.25)).ToString();
        }

        private void quantityTextBox_TextChanged(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            if (String.IsNullOrEmpty(quantityTextBox.Text))
            {
                messageLabel.Text = "Enter Quantity";
                return;
            }
            if (String.IsNullOrEmpty(unitPriceTextBox.Text))
            {
                messageLabel.Text = "Enter Unit Price";
                return;
            }
            totalPriceTextBox.Text = (Convert.ToInt32(quantityTextBox.Text) * Convert.ToInt32(unitPriceTextBox.Text)).ToString();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            purchase = new Purchase();
            purchase.SL = listOfPurchase.Count + 1;
            purchase.SupplierCode = supplierComboBox.SelectedValue.ToString();
            purchase.BillNo = invoiceNoTextBox.Text;
            purchase.Date = Convert.ToDateTime(dateTextBox.Text).ToString("yyyy-MM-dd");
            purchase.ProductCode = productsComboBox.SelectedValue.ToString();
            purchase.ManufacturedDate= Convert.ToDateTime(manufacturedDateTextBox.Text).ToString("dd-MM-yyyy");
            purchase.ExpireDate= Convert.ToDateTime(expireDateTextBox.Text).ToString("dd-MM-yyyy");
            purchase.Quantity = Convert.ToInt32(quantityTextBox.Text);
            purchase.UnitPrice = Convert.ToInt32(unitPriceTextBox.Text);
            purchase.TotalPrice = purchase.Quantity * purchase.UnitPrice;
            purchase.MRP = Convert.ToInt32(newMRPTextBox.Text);
            purchase.Remarks = remarkRichTextBox.Text;
            if(AddButton.Text.Equals("Add"))
            {
                listOfPurchase.Add(purchase);
            }
            else   //Confirm
            {
                listOfPurchase[index - 1].SupplierCode = purchase.SupplierCode;
                listOfPurchase[index - 1].BillNo = purchase.BillNo;
                listOfPurchase[index - 1].Date = purchase.Date;
                listOfPurchase[index - 1].ProductCode = purchase.ProductCode;
                listOfPurchase[index - 1].ManufacturedDate = purchase.ManufacturedDate;
                listOfPurchase[index - 1].ExpireDate = purchase.ExpireDate;
                listOfPurchase[index - 1].Quantity = purchase.Quantity;
                listOfPurchase[index - 1].UnitPrice = purchase.UnitPrice;
                listOfPurchase[index - 1].TotalPrice = purchase.TotalPrice;
                listOfPurchase[index - 1].MRP = purchase.MRP;
                listOfPurchase[index - 1].Remarks = purchase.Remarks;
                AddButton.Text="Add";
            }                       
            Display();           
            productsComboBox.Text = "-Select-";
            codeTextBox.Text = "<View>";
            totalPriceTextBox.Text = "<View>";
            previousCostPriceTextBox.Text = "<View>";
            previousMRPTextBox.Text = "<View>";
            manufacturedDateTextBox.Text = "";
            expireDateTextBox.Text = "";
            quantityTextBox.Text = "";
            unitPriceTextBox.Text = "";
            newMRPTextBox.Text = "";
            remarkRichTextBox.Text = "";
        }
        private void Display()
        {
            purchaseDataGridView.DataSource = null;
            purchaseDataGridView.DataSource = listOfPurchase;               
        }

        private void purchaseDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(purchaseDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals("Edit"))
            {
                index = Convert.ToInt32(purchaseDataGridView.Rows[e.RowIndex].Cells["SL"].Value);
                productsComboBox.SelectedValue = listOfPurchase[index - 1].ProductCode;
                manufacturedDateTextBox.Text = listOfPurchase[index - 1].ManufacturedDate;
                expireDateTextBox.Text = listOfPurchase[index - 1].ExpireDate;
                quantityTextBox.Text = listOfPurchase[index - 1].Quantity.ToString();
                unitPriceTextBox.Text = listOfPurchase[index - 1].UnitPrice.ToString();
                remarkRichTextBox.Text = listOfPurchase[index - 1].Remarks;
                supplierComboBox.SelectedValue = listOfPurchase[index - 1].SupplierCode;
                dateTextBox.Text = listOfPurchase[index - 1].Date;
                invoiceNoTextBox.Text = listOfPurchase[index - 1].BillNo;
                AddButton.Text = "Confirm";
            }
            if (purchaseDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals("Delete"))
            {
                index = Convert.ToInt32(purchaseDataGridView.Rows[e.RowIndex].Cells["SL"].Value);
                listOfPurchase.RemoveAt(index - 1);
                for (int i = 0; i < listOfPurchase.Count; i++)
                {
                    listOfPurchase[i].SL = i + 1;
                }
                Display();
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            for(int i=0;i<listOfPurchase.Count;i++)
            {
                _purchaseManager.AddPurchase(listOfPurchase[i]);
                product = new Product();
                product.CurrentMRP = listOfPurchase[i].MRP;
                product.UnitPrice = listOfPurchase[i].UnitPrice;
                product.Code = listOfPurchase[i].ProductCode;
                product.AvailableQuantity = _purchaseManager.GetAvailableQuantity(product) + listOfPurchase[i].Quantity;
                _purchaseManager.UpdateProduct(product);
            }
            listOfPurchase = new List<Purchase>();
            Display();
            supplierComboBox.Text = "-Select-";
            dateTextBox.Text = "";
            invoiceNoTextBox.Text = "";
        }

        private void AddSupplierButton_Click(object sender, EventArgs e)
        {
            SupplierUi supplierUi = new SupplierUi();
            supplierUi.Show();
            isSupplierAdded = true;
        }

        private void supplierComboBox_Click(object sender, EventArgs e)
        {
            if (isSupplierAdded)
            {
                supplierComboBox.DataSource = _purchaseManager.LoadSupplierToComboBox();
                isSupplierAdded = false;
            }

        }

        
    }
}
