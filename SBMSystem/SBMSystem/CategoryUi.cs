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
    public partial class CategoryUi : Form
    {
        Category category;
        CategoryManager _categoryManager;
        public CategoryUi()
        {
            InitializeComponent();
            category = new Category();
            _categoryManager = new CategoryManager();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string code = codeTextBox.Text;
            displayRichTextBox.Text = _categoryManager.AddCategory(code, name);
        }
    }
}
