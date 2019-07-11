using SBMSystem.BLL.BLL;
using SBMSystem.Models.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SBMSystem
{
    public partial class CustomerUi : Form
    {
        Customer customer;
        CustomerManager _customerManager;
        public CustomerUi()
        {
            InitializeComponent();
            customer = new Customer();
            _customerManager = new CustomerManager();
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
            if(contactTextBox.Text.Length!=11)
            {
                messageLabel.Text = "Enter Exactly 11 digits No.";
                return;                
            }
            if (String.IsNullOrEmpty(loyaltyPointTextBox.Text))
            {
                messageLabel.Text = "Enter Loyalty Point";
                return;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(loyaltyPointTextBox.Text, "[^0-9]"))
            {
                messageLabel.Text = "Ender Numeric Loyalty Point";
                return;
            }              
            if (customerPictureBox.Image == null)
            {
                messageLabel.Text = "Enter a Customer Pic";
                return;
            }
            if (!new EmailAddressAttribute().IsValid(emailTextBox.Text))
            {
                messageLabel.Text = "Invalid Email Address";
                return;
            }
            customer.Code = codeTextBox.Text;
            if(_customerManager.IsCodeDuplicate(customer))
            {
                messageLabel.Text = "Code is Duplicate,Enter unique code";
                return;
            }
            customer.Name = nameTextBox.Text;
            customer.Address = addressTextBox.Text;
            customer.Email = emailTextBox.Text;
            customer.Contact = contactTextBox.Text;
            customer.LoyaltyPoint = Convert.ToInt32(loyaltyPointTextBox.Text);
            if (_customerManager.AddCustomer(customer))
            {
                messageLabel.ForeColor = Color.Green;
                messageLabel.Text = "Customer saved";
            }
            else
            {
                messageLabel.Text = "Customer Not saved";
            }
            codeTextBox.Text = "";
            nameTextBox.Text = "";
            addressTextBox.Text = "";
            emailTextBox.Text = "";
            contactTextBox.Text = "";
            customerPictureBox.Image = null;
            loyaltyPointTextBox.Text = "";

        }

        private void AddCustomerButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap(openFileDialog.FileName);
                customerPictureBox.Image = bitmap;
                customerPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            try
            {
                MemoryStream memoryStram = new MemoryStream();
                customerPictureBox.Image.Save(memoryStram, customerPictureBox.Image.RawFormat);
                byte[] image = memoryStram.ToArray();
                customer.ImageCustomer = Convert.ToBase64String(image);

            }
            catch (Exception exception)
            {
                messageLabel.ForeColor = Color.Red;
                messageLabel.Text = exception.Message;
            }
        }
    }
}
