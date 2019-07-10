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
                MessageBox.Show(exception.Message);
            }
            //try
            //{
            //    string FileName = "";
            //    OpenFileDialog openFileDialog = new OpenFileDialog();
            //    if (openFileDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        FileName = openFileDialog.FileName;
            //        Bitmap bitmap = new Bitmap(FileName);
            //        productPictureBox.Image = bitmap;
            //        productPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            //    }
            //    byte[] imageData;
            //    FileStream fileStream = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            //    BinaryReader binaryReader = new BinaryReader(fileStream);
            //    imageData = binaryReader.ReadBytes((int)fileStream.Length);
            //    binaryReader.Close();
            //    fileStream.Close();
            //    product.ImageProduct = imageData.ToString();

            //}
            //catch(Exception exception)
            //{

            //}
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            product.Code = codeTextBox.Text;
            product.Name = nameTextBox.Text;
            product.CategoryCode = categoryComboBox.SelectedValue.ToString();
            product.ReorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);
            product.Description = descriptionRichTextBox.Text;
            if(_productManager.AddProduct(product))
            {
                MessageBox.Show("Product saved");
            }
            else
            {
                MessageBox.Show("Not saved");
            }
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
               
                productPictureBox.Image = System.Drawing.Image.FromStream(memoryStream, true);
                productPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
