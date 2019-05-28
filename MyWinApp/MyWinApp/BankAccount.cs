using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinApp
{
    public partial class BankAccount : Form
    {
        List<string> userNames = new List<string>();
        List<string> firstNames = new List<string>();
        List<string> lastNames = new List<string>();
        List<int> contactNos = new List<int>();
        List<string> emails = new List<string>();
        List<string> addresss = new List<string>();
        List<int> accountNos = new List<int>();


        public BankAccount()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string userName;
                string firstName;
                string lastName;
                int contactNo;
                string email;
                string address;
                int accountNo;

                userName = userNameTextBox.Text;
                if(String.IsNullOrEmpty(userName))
                {
                    MessageBox.Show("Enter User Name Please!");
                    return;
                }
                firstName = firstNameTextBox.Text;
                lastName = lastNameTextBox.Text;
                if (String.IsNullOrEmpty(contactNoTextBox.Text))
                {
                    MessageBox.Show("Enter Contact No. Please!");
                    return;
                }
                contactNo = Convert.ToInt32(contactNoTextBox.Text);
                email = emailTextBox.Text;
                if (String.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Enter Your Email Please!");
                    return;
                }
                address = addressTextBox.Text;
                if (String.IsNullOrEmpty(accountNoTextBox.Text))
                {
                    MessageBox.Show("Enter User Account No. Please!");
                    return;
                }
                accountNo = Convert.ToInt32(accountNoTextBox.Text);

                userNames.Add(userName);
                firstNames.Add(firstName);
                lastNames.Add(lastName);
                contactNos.Add(contactNo);
                emails.Add(email);
                addresss.Add(address);
                accountNos.Add(accountNo);

            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            showRichTextBox.Text = Display();
        }
        private string Display()
        {
            string message = "";
            message = "SI\tUser Name:\tFirst Name\tLast Name\tContact No\tEmail\tAddress\tAccount No.\n";
            for (int index = 0; index < userNames.Count; index++)
            {
                message += (index + 1) + "\t" + userNames[index] + "\t" + firstNames[index] + "\t" + lastNames[index] + "\t" + contactNos[index] + "\t" + emails[index] + "\t" + addresss[index] + "\t" + accountNos[index] + "\n";

            }
            return message;
        }
    }
}
