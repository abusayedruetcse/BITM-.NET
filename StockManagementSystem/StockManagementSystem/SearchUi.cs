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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

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

        private void PDFButton_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Search.pdf",FileMode.Create));
            doc.Open();
            //Paragraph paragraph = new Paragraph("Search and View Item Summary"+Environment.NewLine);
            //doc.Add(paragraph);
            //adding the headers 
            int noOfColumn = 6;
            PdfPTable table = new PdfPTable(noOfColumn);           
            for(int i=0;i<noOfColumn;i++)
            {
                table.AddCell(new Phrase(searchViewSummaryDataGridView.Columns[i].HeaderText));
            }
            table.HeaderRows = 1;
            for(int y=0;y<searchViewSummaryDataGridView.Rows.Count;y++)
            {
                for(int x=0;x<noOfColumn;x++)
                {
                    if(searchViewSummaryDataGridView[x,y].Value!=null)
                    {
                        table.AddCell(new Phrase(searchViewSummaryDataGridView[x,y].Value.ToString()));
                    }
                }
            }
            doc.Add(table);
            doc.Close();
            MessageBox.Show("PDF successfully created");
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuUi menuUi = new MenuUi();
            menuUi.Show();
        }
    }
}
