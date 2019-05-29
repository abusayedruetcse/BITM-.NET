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
    public partial class ListExercise : Form
    {
        List<int> numbers = new List<int>();
        public ListExercise()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                int number;
                if(System.Text.RegularExpressions.Regex.IsMatch(addTextBox.Text,"[^0-9]"))
                {
                    MessageBox.Show("Enter Numeric Digits only!");
                    return;
                }
                number = Convert.ToInt32(addTextBox.Text);
                numbers.Add(number);

            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            showRichTextBox.Text = Display("Added List Elements are");
        }
        private string Display(string message)
        {
            message += ":\n";
            foreach(int number in numbers)
            {
                message += number + " ";
            }
            message += "\n";
            return message;
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            showRichTextBox.Text = Display("Elements in List are");
        }
    }
}
