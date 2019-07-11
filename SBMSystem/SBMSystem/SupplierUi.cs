using SBMSystem.BLL.BLL;
using SBMSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SBMSystem
{
    public partial class SupplierUi : Form
    {
        Supplier supplier;
        SupplierManager _supplierManager;
        public SupplierUi()
        {
            InitializeComponent();
            supplier = new Supplier();
            _supplierManager = new SupplierManager();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            messageLabel.ForeColor = Color.Red;
            if (String.IsNullOrEmpty(codeTextBox.Text))
            {
                messageLabel.Text = "Enter a Customer Code";
                return;
            }
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                messageLabel.Text = "Enter a Customer Name";
                return;
            }
            if (String.IsNullOrEmpty(addressTextBox.Text))
            {
                messageLabel.Text = "Enter your address";
                return;
            }
            if (String.IsNullOrEmpty(emailTextBox.Text))
            {
                messageLabel.Text = "Enter email address";
                return;
            }
            if (!new EmailAddressAttribute().IsValid(emailTextBox.Text))
            {
                messageLabel.Text = "Invalid Email Address";
                return;
            }
            if (String.IsNullOrEmpty(contactTextBox.Text))
            {
                messageLabel.Text = "Enter your contact No.";
                return;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(contactTextBox.Text, "[^0-9]"))
            {
                messageLabel.Text = "Ender Numeric digits contact No.";
                return;
            }
            if (contactTextBox.Text.Length != 11)
            {
                messageLabel.Text = "Enter Exactly 11 digits Contact No.";
                return;
            }
            if (String.IsNullOrEmpty(contactPersonTextBox.Text))
            {
                messageLabel.Text = "Enter Contact Person No.";
                return;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(contactPersonTextBox.Text, "[^0-9]"))
            {
                messageLabel.Text = "Ender Numeric Contact Person No.";
                return;
            }
            if(contactPersonTextBox.Text.Length!=11)
            {
                messageLabel.Text= "Enter Exactly 11 digits Contact Person No.";
                return;
            }
            if (logoPictureBox.Image == null)
            {
                messageLabel.Text = "Enter a Logo Pic";
                return;
            }   
            supplier.Code = codeTextBox.Text;
            if (_supplierManager.IsCodeDuplicate(supplier))
            {
                messageLabel.Text = "Code is Duplicate,Enter unique code";
                return;
            }

            supplier.Code = codeTextBox.Text;
            supplier.Name = nameTextBox.Text;
            supplier.Address = addressTextBox.Text;
            supplier.Email = emailTextBox.Text;
            supplier.Contact = contactTextBox.Text;
            supplier.ContactPerson = contactPersonTextBox.Text;

            if(_supplierManager.AddSupplier(supplier))
            {
                messageLabel.ForeColor = Color.Green;
                messageLabel.Text = "Supplier saved";
            }
            else
            {
                messageLabel.Text = "Supplier Not saved";
            }
            codeTextBox.Text = "";
            nameTextBox.Text = "";
            addressTextBox.Text = "";
            emailTextBox.Text = "";
            contactTextBox.Text = "";
            logoPictureBox.Image = null;
            contactPersonTextBox.Text = "";
            logoPictureLabel.Text = "Logo";
        }

        private void AddLogoButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                logoPictureLabel.Text = "";
                Bitmap bitmap = new Bitmap(openFileDialog.FileName);
                logoPictureBox.Image = bitmap;
                logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            try
            {
                MemoryStream memoryStram = new MemoryStream();
                logoPictureBox.Image.Save(memoryStram, logoPictureBox.Image.RawFormat);
                byte[] image = memoryStram.ToArray();
                supplier.ImageLogo= Convert.ToBase64String(image);

            }
            catch (Exception exception)
            {
                messageLabel.ForeColor = Color.Red;
                messageLabel.Text = exception.Message;
            }
        }
    }
}
