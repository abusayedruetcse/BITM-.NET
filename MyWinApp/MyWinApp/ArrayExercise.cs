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
    public partial class ArrayExercise : Form
    {
        const int size = 10;
        int[] numbers = new int[size];
        int count = 0;

        public ArrayExercise()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            numbers[count] = Convert.ToInt32(numberTextBox.Text);
            count++;           
            showRichTextBox.Text = Display("Elements in array are");
        }

        private void ReverseButton_Click(object sender, EventArgs e)
        {
            string message = "";
            message += Display("The values store into the array are");
            message += "The values store into the array in reverse are : \n";
            for(int index=count-1; index>=0; index--)
            {
                message += numbers[index] + " ";
            }
            showRichTextBox.Text = message;
        }
        private string Display(string message)
        {
            message += ":\n";
            for(int index=0; index<count; index++)
            {
                message += numbers[index] + " ";
            }
            message += "\n";
            return message;
        }

        private void SumButton_Click(object sender, EventArgs e)
        {
            int sumNumbers;
            string message = "";
            message += Display("The values store into the array are");
            message += "Sum of all elements stored in the array is: ";
            sumNumbers = 0;
            for(int index=0; index<count; index++)
            {
                sumNumbers += numbers[index];
            }
            message += sumNumbers;
            showRichTextBox.Text = message;
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            int[] copyNumbers = new int[size];
            string message = "";
            message += Display("The elements stored in the first array are");
            message += "The elements copied into the second array are :\n";
            for(int index=0; index<count; index++)
            {
                copyNumbers[index] = numbers[index];
            }
            for(int index=0; index<count; index++)
            {
                message += copyNumbers[index] + " ";
            }
            showRichTextBox.Text = message;
        }
    }
}
