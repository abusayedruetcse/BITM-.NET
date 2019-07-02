using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystem.BLL;

namespace StockManagementSystem
{
    public partial class SearchUi : Form
    {
        SearchManager _searchManager;
        bool isCompanyLoaded;
        bool isCategoryLoaded;
        DataTable dataTable;
        public SearchUi()
        {
            InitializeComponent();
            _searchManager = new SearchManager();
            dataTable = new DataTable();
        }

        private void SearchUi_Load(object sender, EventArgs e)
        {
            companyComboBox.DataSource= _searchManager.LoadCompanyToComboBox();
            ReloadCategory();
        }
        private void ReloadCategory()
        {
            categoryComboBox.DataSource= _searchManager.LoadCategoryToComboBox();
            isCompanyLoaded = false;
            isCategoryLoaded = false;
            companyComboBox.Text = "";
            categoryComboBox.Text = "";
        }

        private void companyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            isCompanyLoaded = true;
            //dataTable = _searchManager.LoadFilteredCategoryToComboBox(Convert.ToInt32(companyComboBox.SelectedValue));           
            //categoryComboBox.DataSource = dataTable;
            //categoryComboBox.Text = "";
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            isCategoryLoaded = true;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if((isCategoryLoaded==true)&&(isCompanyLoaded==true))
            {
                int cat = Convert.ToInt32(categoryComboBox.SelectedValue);
                int com = Convert.ToInt32(companyComboBox.SelectedValue);
                dataTable = _searchManager.LoadFilteredItemToDataGridView(cat,com , isCompanyLoaded, isCategoryLoaded);

            } else if(isCategoryLoaded)
            {
                dataTable = _searchManager.LoadFilteredItemToDataGridView(Convert.ToInt32(categoryComboBox.SelectedValue),0, isCompanyLoaded, isCategoryLoaded);
            }
            else
            {
               dataTable = _searchManager.LoadFilteredItemToDataGridView(0, Convert.ToInt32(companyComboBox.SelectedValue), isCompanyLoaded, isCategoryLoaded);
            }
            searchViewSummaryDataGridView.DataSource = dataTable;
            foreach(DataGridViewRow row in searchViewSummaryDataGridView.Rows)
            {
                row.Cells["SL"].Value = (row.Index + 1).ToString();
            }
            if(dataTable.Rows.Count==0)
            {
                MessageBox.Show("No Data Found!");
            }
            ReloadCategory();

        }
    }
}
