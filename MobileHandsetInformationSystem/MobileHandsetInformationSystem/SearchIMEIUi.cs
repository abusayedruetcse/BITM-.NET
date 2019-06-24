using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MobileHandsetInformationSystem.BLL;
using MobileHandsetInformationSystem.Models;

namespace MobileHandsetInformationSystem
{
    public partial class SearchIMEIUi : Form
    {
        MobileModel mobileModel;
        MobileModelManager _mobileModelManager;
        public SearchIMEIUi()
        {
            InitializeComponent();
            mobileModel = new MobileModel();
            _mobileModelManager = new MobileModelManager();
            messageLabel.Text = "";
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            modelNameLabel.Text = "";
            iMEILabel.Text = "";
            priceLabel.Text = "";
            messageLabel.Text = "";
            if (String.IsNullOrEmpty(iMEITextBox.Text))
            {
                messageLabel.Text = "Enter IMEI";
                return;
            }
            if(iMEITextBox.Text.Length!=15)
            {
                messageLabel.Text = "Enter 15 length long IMEI";
                return;
            }
            mobileModel.IMEI = iMEITextBox.Text;
            DataTable dataTable = _mobileModelManager.SearchByIMEI(mobileModel);
            if(dataTable.Rows.Count>0)
            {
                DataRow row = dataTable.Rows[0];
                modelNameLabel.Text = row["ModelName"].ToString();
                iMEILabel.Text = row["IMEI"].ToString();
                priceLabel.Text = row["Price"].ToString();
            }
            else
            {
                messageLabel.Text = "Not Found!";                
            }
            iMEITextBox.Text = "";
        }

        
    }
}
