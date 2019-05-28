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
                userNameLabel.Text = "";
                if(IsUserDuplicateExists(userName))
                {
                    userNameLabel.Text = "Duplicate User Name Found";
                    return;
                }
   
                firstName = firstNameTextBox.Text;
                lastName = lastNameTextBox.Text;

                if (String.IsNullOrEmpty(contactNoTextBox.Text))
                {
                    MessageBox.Show("Enter Contact No. Please!");
                    return;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(contactNoTextBox.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    return;
                }
                if(contactNoTextBox.TextLength!=11)
                {
                    MessageBox.Show("Enter Contact No. 11 Numeric Digits Only!");
                    return;
                }
                contactNo = Convert.ToInt32(contactNoTextBox.Text);
                contactNoLabel.Text = "";
                if (IsContactNoDuplicateExists(contactNo))
                {
                    contactNoLabel.Text = "Duplicate Contact No Found";
                    return;
                }

                email = emailTextBox.Text;
                if (String.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Enter Your Email Please!");
                    return;
                }
                emailLabel.Text = "";
                if (IsEmailDuplicateExists(email))
                {
                    emailLabel.Text = "Duplicate Email Found";
                    return;
                }

                address = addressTextBox.Text;

                if (String.IsNullOrEmpty(accountNoTextBox.Text))
                {
                    MessageBox.Show("Enter User Account No. Please!");
                    return;
                }
                accountNo = Convert.ToInt32(accountNoTextBox.Text); 
                accountNoLabel.Text = "";
                if (IsAccountNoDuplicateExists(accountNo))
                {
                    accountNoLabel.Text = "Duplicate Account No Found";
                    return;
                }

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
        private bool IsUserDuplicateExists(string userName)
        {
            bool isExist = false;
            foreach(string checkUserName in userNames)
            {
                if(checkUserName==userName)
                {
                    isExist = true;
                }
            }
            return isExist;
        }
        private bool IsContactNoDuplicateExists(int contactNo)
        {
            bool isExist = false;
            foreach (int checkContactNo in contactNos)
            {
                if (checkContactNo == contactNo)
                {
                    isExist = true;
                }
            }
            return isExist;
        }
        private bool IsEmailDuplicateExists(string email)
        {
            bool isExist = false;
            foreach (string checkEmail in emails)
            {
                if (checkEmail == email)
                {
                    isExist = true;
                }
            }
            return isExist;
        }
        private bool IsAccountNoDuplicateExists(int accountNo)
        {
            bool isExist = false;
            foreach (int checkAccountNo in accountNos)
            {
                if (checkAccountNo == accountNo)
                {
                    isExist = true;
                }
            }
            return isExist;
        }
    }
}
