using SBMSystem.BLL.BLL;
using SBMSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMSystem
{
    public partial class ProductUi : Form
    {
        Product product;
        ProductManager _productManager;
        bool isAddCategoryButtonClicked = false;
        public ProductUi()
        {
            InitializeComponent();
            _productManager = new ProductManager();
            product = new Product();
        }

        private void ProductUi_Load(object sender, EventArgs e)
        {
            categoryComboBox.DataSource = _productManager.LoadCategoryToComboBox();
            categoryComboBox.Text = "-Select-";
            productPictureBox.Image = null;
            DisplayProducts();
        }

        private void AddCategoryButton_Click(object sender, EventArgs e)
        {
            CategoryUi categoryUi = new CategoryUi();
            categoryUi.Show();
            isAddCategoryButtonClicked = true;                     
        }

        private void categoryComboBox_Click(object sender, EventArgs e)
        {
            if(isAddCategoryButtonClicked)
            {
                categoryComboBox.DataSource = _productManager.LoadCategoryToComboBox();
            }
            isAddCategoryButtonClicked = false;
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                productPictureLabel.Text = "";
                Bitmap bitmap = new Bitmap(openFileDialog.FileName);
                productPictureBox.Image = bitmap;
                productPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            try
            {
                MemoryStream memoryStram = new MemoryStream();
                productPictureBox.Image.Save(memoryStram, productPictureBox.Image.RawFormat);
                byte[] image = memoryStram.ToArray();
                product.ImageProduct = Convert.ToBase64String(image);

            }
            catch (Exception exception)
            {
                messageLabel.ForeColor = Color.Red;
                messageLabel.Text = exception.Message;
            }          
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            messageLabel.ForeColor = Color.Red;
            if(String.IsNullOrEmpty(codeTextBox.Text))
            {
                messageLabel.Text = "Enter a Product Code";
                return;
            }
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                messageLabel.Text = "Enter a Product Name";
                return;
            }
            if (categoryComboBox.Text.Equals("-Select-"))
            {
                messageLabel.Text = "Select Or Add a Category";
                return;
            }
            if (String.IsNullOrEmpty(reorderLevelTextBox.Text))
            {
                messageLabel.Text = "Enter a ReorderLevel";
                return;
            } 
            if(System.Text.RegularExpressions.Regex.IsMatch(reorderLevelTextBox.Text,"[^0-9]"))
            {
                messageLabel.Text = "Ender Numeric Reorder Level";
                return;
            }
            
            if (productPictureBox.Image==null)
            {
                messageLabel.Text = "Enter a Product Pic";
                return;
            }
            product.Name = nameTextBox.Text;
            product.CategoryCode = categoryComboBox.SelectedValue.ToString();
            product.ReorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);
            product.Description = descriptionRichTextBox.Text;
            
            if(SaveButton.Text.Equals("Save"))
            {
                product.Code = codeTextBox.Text;
                if(_productManager.IsCodeDuplicate(product))
                {
                    messageLabel.Text = "Product Code is Duplicate";
                    codeTextBox.Text = "";
                    return;
                }
                if (_productManager.AddProduct(product))
                {
                    messageLabel.ForeColor = Color.Green;
                    messageLabel.Text = "Product saved";
                }
                else
                {
                    messageLabel.Text = "Not saved";
                }
            }else
            {
                if(_productManager.UpdateProduct(product))
                {
                    messageLabel.ForeColor = Color.Green;
                    messageLabel.Text = "Successfully Updated";
                } 
                else
                {
                    messageLabel.Text = "Updated Failed";
                }

                SaveButton.Text = "Save";
            }
            codeTextBox.Text = "";
            nameTextBox.Text = "";
            categoryComboBox.Text = "-Select-";
            reorderLevelTextBox.Text = "";
            productPictureBox.Image = null;
            descriptionRichTextBox.Text = "";
            productPictureLabel.Text = "Product";
            DisplayProducts();
        }
        private void DisplayProducts()
        {
            productDataGridView.DataSource = _productManager.GetProducts();
            for(int i=0;i<productDataGridView.Rows.Count-1;i++)
            {
                productDataGridView.Rows[i].Cells["SL"].Value = (i + 1).ToString();
                productDataGridView.Rows[i].Cells["EditButton"].Value = "Edit";
                productDataGridView.Rows[i].Cells["DeleteButton"].Value = "Delete";
                
                byte[] imageBytes = Convert.FromBase64String(productDataGridView.Rows[i].Cells["imageProductDataGridViewTextBoxColumn"].Value.ToString());
                MemoryStream memoryStream = new MemoryStream(imageBytes, 0, imageBytes.Length);
                memoryStream.Write(imageBytes, 0, imageBytes.Length);
                productDataGridView.Rows[i].Cells["Image"].Value = System.Drawing.Image.FromStream(memoryStream, true);                  
            }
        }

        private void productDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            messageLabel.Text = "";
            messageLabel.ForeColor = Color.Red;
            try
            {
                if (productDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals("Edit"))
                {
                    codeTextBox.Text = productDataGridView.Rows[e.RowIndex].Cells["codeDataGridViewTextBoxColumn"].Value.ToString();
                    nameTextBox.Text = productDataGridView.Rows[e.RowIndex].Cells["nameDataGridViewTextBoxColumn"].Value.ToString();
                    categoryComboBox.Text = productDataGridView.Rows[e.RowIndex].Cells["Category"].Value.ToString();
                    reorderLevelTextBox.Text = productDataGridView.Rows[e.RowIndex].Cells["reorderLevelDataGridViewTextBoxColumn"].Value.ToString();
                    descriptionRichTextBox.Text = productDataGridView.Rows[e.RowIndex].Cells["descriptionDataGridViewTextBoxColumn"].Value.ToString();

                    productPictureLabel.Text = "";
                    byte[] imageBytes = Convert.FromBase64String(productDataGridView.Rows[e.RowIndex].Cells["imageProductDataGridViewTextBoxColumn"].Value.ToString());
                    MemoryStream memoryStream = new MemoryStream(imageBytes, 0, imageBytes.Length);
                    memoryStream.Write(imageBytes, 0, imageBytes.Length);
                    productDataGridView.Rows[e.RowIndex].Cells["Image"].Value = System.Drawing.Image.FromStream(memoryStream, true);

                    productPictureBox.Image = System.Drawing.Image.FromStream(memoryStream, true);
                    productPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    product.Code = codeTextBox.Text;
                    product.ImageProduct = Convert.ToBase64String(imageBytes);
                    SaveButton.Text = "Confirm";
                }
                if (productDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.Equals("Delete"))
                {
                    if(SaveButton.Text.Equals("Confirm"))
                    {
                        messageLabel.Text = "Click Confirm first";
                        return;
                    }
                    if (_productManager.DeleteProduct(product))
                    {
                        messageLabel.ForeColor = Color.Green;
                        messageLabel.Text = "Successfully Deleted";
                    }
                    else
                    {
                        messageLabel.Text = "Deletion Failed";
                    }
                    DisplayProducts();
                }
            }catch(Exception exception)
            {
                messageLabel.ForeColor = Color.Red;
                messageLabel.Text = exception.Message;
            }
        }
    }
}
