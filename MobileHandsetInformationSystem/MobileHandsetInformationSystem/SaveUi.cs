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
    public partial class SaveUi : Form
    {
        MobileModelManager _mobileModelManager;
        MobileModel mobileModel;
        public SaveUi()
        {
            InitializeComponent();           
        }
        private void SaveUi_Load(object sender, EventArgs e)
        {
            mobileModel = new MobileModel();
            _mobileModelManager = new MobileModelManager();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(modelNameTextBox.Text))
            {
                messageLabel.Text = "Name is Empty";
                return;
            }
            mobileModel.ModelName = modelNameTextBox.Text;
            if (String.IsNullOrEmpty(iMEITextBox.Text))
            {
                messageLabel.Text = "IMEI is Empty";
                return;
            }
            if(iMEITextBox.Text.Length!=15)
            {
                messageLabel.Text = "Enter Exactly 15 length IMEI";
                return;
            }
            mobileModel.IMEI = iMEITextBox.Text;

            if (_mobileModelManager.IsIMEIDuplicate(mobileModel))
            {
                messageLabel.Text = "Enter Unique IMEI";
                return;
            } 
            if(String.IsNullOrEmpty(priceTextBox.Text))
            {
                messageLabel.Text = "Enter Price";
                return;
            }
            mobileModel.Price = Convert.ToInt32(priceTextBox.Text);
            int isExecuted = 0;
            isExecuted = _mobileModelManager.InsertModel(mobileModel);
            if(isExecuted>0)
            {
                messageLabel.Text = "Mobile Model Saved";
            }
            else
            {
                messageLabel.Text = "Save Failed";
            }
        }

        
    }
}
