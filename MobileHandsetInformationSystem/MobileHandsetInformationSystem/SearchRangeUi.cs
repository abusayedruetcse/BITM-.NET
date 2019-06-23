using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MobileHandsetInformationSystem.Models;
using MobileHandsetInformationSystem.BLL;

namespace MobileHandsetInformationSystem
{
    public partial class SearchRangeUi : Form
    {
        MobileModelManager _mobileModelManager;
        public SearchRangeUi()
        {
            InitializeComponent();
        }   
        private void SearchRangeUi_Load(object sender, EventArgs e)
        {
           _mobileModelManager = new MobileModelManager(); 
        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _mobileModelManager.SearchByPrice(fromTextBox.Text, toTextBox.Text);
            dataGridView1.RowHeadersVisible = false;
            
        }
    }
}
