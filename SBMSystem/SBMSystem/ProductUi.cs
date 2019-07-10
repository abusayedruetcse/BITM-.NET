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
        public ProductUi()
        {
            InitializeComponent();
            _productManager = new ProductManager();
        }
    }
}
