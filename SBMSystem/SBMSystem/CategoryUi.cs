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
        public CategoryUi()
        {
            InitializeComponent();
            category = new Category();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string code = codeTextBox.Text;
            category.Name = name;
            category.Code = code;
            displayRichTextBox.Text = "Code: " + category.Code + Environment.NewLine + "Name: " + category.Name;
        }
    }
}
