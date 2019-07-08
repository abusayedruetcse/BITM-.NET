using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystem.Models;
using StockManagementSystem.BLL;
using System.Data;

namespace StockManagementSystem
{
    public partial class CompanyUi : Form
    {
        CompanyManager _companyManager;
        Company company;
        History history;
        DataTable dataTable;
        public CompanyUi()
        {
            InitializeComponent();
            _companyManager = new CompanyManager();
            company = new Company();
            history = new History();
            dataTable = new DataTable();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            history.UserID = UserAccount.ID;
            history.TableName = "Companies";
            history.DateAndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string name = "";
            name = nameTextBox.Text;
            if (String.IsNullOrEmpty(name))
            {
                messageLabel.ForeColor = Color.Red;
                messageLabel.Text = "Company Name Field is Empty";
                return;
            }
            company.Name = name;
            if (SaveButton.Text.Equals("Save"))
            {
                if (_companyManager.IsCompanyDuplicate(company))
                {
                    messageLabel.ForeColor = Color.Red;
                    messageLabel.Text = "Company is Duplicate";
                    return;
                }
                Insert(name);
            }
            else   //update
            {
                dataTable = _companyManager.IsUpdateCompanyDuplicate(company);
                if (dataTable.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dataTable.Rows[0]["ID"]) == company.ID)
                    {
                        messageLabel.ForeColor = Color.Green;
                        messageLabel.Text = "Company is Unchanged";
                    }
                    else
                    {
                        messageLabel.ForeColor = Color.Red;
                        messageLabel.Text = "Company is Duplicate";
                    }
                    return;
                }
                history.TableRowNo = company.ID;               
                Update(name);
                SaveButton.Text = "Save";
            }
            nameTextBox.Text = "";
            Display();
        }
        private void Insert(string name)
        {
            company.Name = name;
            history.Element = name;
            int isExecuted = 0;
            isExecuted = _companyManager.Insert(company,history);
            if (isExecuted > 0)
            {
                messageLabel.ForeColor = Color.Green;
                messageLabel.Text = "Saved Successfully";
            }
            else
            {
                messageLabel.ForeColor = Color.Red;
                messageLabel.Text = "Save Failed!";
            }            
        }
        private void Update(string name)
        {
            company.Name = name;
            history.Element = name;
            int isExecuted = 0;
            isExecuted = _companyManager.Update(company,history);
            if (isExecuted > 0)
            {
                messageLabel.ForeColor = Color.Green;
                messageLabel.Text = "Updated Successfully";
            }
            else
            {
                messageLabel.ForeColor = Color.Red;
                messageLabel.Text = "Update Failed!";
            }            
        }
        private void Display()
        {            
            companyDataGridView.DataSource = _companyManager.Display();
            foreach (DataGridViewRow row in companyDataGridView.Rows)
                row.Cells["SL"].Value = (row.Index + 1).ToString();
            history.TableRowNo = companyDataGridView.Rows.Count + 1;
        }

        private void companyDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (companyDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    companyDataGridView.CurrentRow.Selected = true;
                    nameTextBox.Text = companyDataGridView.Rows[e.RowIndex].Cells["NameColumn"].FormattedValue.ToString();
                    company.ID = Convert.ToInt32(companyDataGridView.Rows[e.RowIndex].Cells["IDColumn"].FormattedValue);
                    SaveButton.Text = "Update";

                }
            }catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }

        private void CompanySetup_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuUi menuUi = new MenuUi();
            menuUi.Show();
        }
    }
}
