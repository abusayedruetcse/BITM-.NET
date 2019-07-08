using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystem.Models;
using StockManagementSystem.BLL;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace StockManagementSystem
{
    public partial class ViewUi : Form
    {
        DataTable dataTable;
        ViewManager _viewManager;
        public ViewUi()
        {
            InitializeComponent();
            dataTable = new DataTable();
            _viewManager = new ViewManager();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string fromDate = fromDateTimePicker.Value.ToString("yyyy-MM-dd");
            string toDate = toDateTimePicker.Value.ToString("yyyy-MM-dd");
            string action="";
            if(soldRadioButton.Checked==true)
            {
                action = "Sell";
            }else if(damagedRadioButton.Checked==true)
            {
                action = "Damage";
            }else
            {
                action = "Lost";
            }
            dataTable = _viewManager.LoadStockOutToDataGridView(fromDate, toDate, action);
            viewReportDataGridView.DataSource = dataTable;
            foreach(DataGridViewRow row in viewReportDataGridView.Rows)
            {
                row.Cells["SL"].Value = (row.Index + 1).ToString();
            }
            if(dataTable.Rows.Count==0)
            {
                MessageBox.Show("No Data Found");
            }
        }

        private void PDFButton_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("View.pdf", FileMode.Create));
            doc.Open();
            //Paragraph paragraph = new Paragraph("Search and View Item Summary"+Environment.NewLine);
            //doc.Add(paragraph);
            //adding the headers 
            int noOfColumn = 4;
            PdfPTable table = new PdfPTable(noOfColumn);
            for (int i = 0; i < noOfColumn; i++)
            {
                table.AddCell(new Phrase(viewReportDataGridView.Columns[i].HeaderText));
            }
            table.HeaderRows = 1;
            for (int y = 0; y < viewReportDataGridView.Rows.Count; y++)
            {
                for (int x = 0; x < noOfColumn; x++)
                {
                    if (viewReportDataGridView[x, y].Value != null)
                    {
                        table.AddCell(new Phrase(viewReportDataGridView[x, y].Value.ToString()));
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
