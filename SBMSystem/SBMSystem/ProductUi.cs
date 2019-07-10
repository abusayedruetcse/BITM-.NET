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
    public partial class ProductUi : Form
    {
        Product product;
        ProductManager _productManager;
        bool isAddCategoryButtonClicked = false;
        public ProductUi()
        {
            InitializeComponent();
            _productManager = new ProductManager();
        }

        private void ProductUi_Load(object sender, EventArgs e)
        {
            categoryComboBox.DataSource = _productManager.LoadCategoryToComboBox();
            categoryComboBox.Text = "-Select-";
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
    }
}
