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

        private void ReverseButton_Click(object sender, EventArgs e)
        {
            string message = "";
            message += Display("The values stored into the List are");
            message += "The values stored into the List in Reverse are";
            message += ":\n";
            for(int index=numbers.Count-1; index>=0; index--)
            {
                message += numbers[index] + " ";
            }
            message += "\n";

            showRichTextBox.Text = message;
        }

        private void SumButton_Click(object sender, EventArgs e)
        {
            int sumElements;
            string message = "";
            message += Display("The values stored into the List are");
            message += "Sum of all Elements stored in the List is: ";
            sumElements = 0;
            foreach(int number in numbers)
            {
                sumElements += number;
            }
            message += sumElements;

            showRichTextBox.Text = message;
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            List<int> copyNumbers = new List<int>();
            string message = "";
            message += Display("The values stored into the List are");
            message += "The Elements copied into the second List are: ";
            message += ":\n";
            foreach(int number in numbers)
            {
                copyNumbers.Add(number);
            }
            foreach(int copyNumber in copyNumbers)
            {
                message += copyNumber + " ";
            }
            message += "\n";
            showRichTextBox.Text = message;
        }

        private void DuplicateButton_Click(object sender, EventArgs e)
        {
            List<int> duplicateNumbers = new List<int>();
            bool[] IsDoneNumber = new bool[numbers.Count];
            bool IsDuplicate;
            string message = "";
            message += Display("The values stored into the List are");
            message += "The Duplicate Elements into the List are: ";
            message += ":\n";
            for (int firstIndex = 0; firstIndex < numbers.Count; firstIndex++)
            {
                IsDuplicate = false;
                if (!IsDoneNumber[firstIndex])
                {
                    IsDoneNumber[firstIndex] = true;
                    for (int secondIndex = firstIndex + 1; secondIndex < numbers.Count; secondIndex++)
                    {
                        if (numbers[firstIndex] == numbers[secondIndex])
                        {
                            IsDoneNumber[secondIndex] = true;
                            IsDuplicate = true;
                        }
                    }
                }
                if (IsDuplicate)
                {
                    duplicateNumbers.Add(numbers[firstIndex]);
                }
            }
            foreach (int duplicateNumber in duplicateNumbers)
            {
                message += duplicateNumber + " ";
            }
            message += "\n";

            message += "Total number of Duplicate Elements is: ";
            message += duplicateNumbers.Count;
            showRichTextBox.Text = message;
        }

        private void UniqueButton_Click(object sender, EventArgs e)
        {
            List<int> uniqueNumbers = new List<int>();
            bool[] isDone = new bool[numbers.Count];
            bool isUnique=false;
            string message = "";
            message += Display("The values stored into the List are");
            message += "The Unique Elements into the List are: ";
            message += ":\n";
            for(int firstIndex=0; firstIndex<numbers.Count; firstIndex++)
            {            
                if(!isDone[firstIndex])
                {
                    isUnique = true;
                    isDone[firstIndex] = true;
                    for(int secondIndex=firstIndex+1; secondIndex<numbers.Count; secondIndex++)
                    {
                        if(!isDone[secondIndex])
                        {
                            if(numbers[firstIndex]==numbers[secondIndex])
                            {
                                isUnique = false;
                                isDone[secondIndex] = true;
                            }
                        }
                    }
                } 
                if(isUnique)
                {
                    uniqueNumbers.Add(numbers[firstIndex]);
                }
            }
            foreach(int uniqueNumber in uniqueNumbers)
            {
                message += uniqueNumber + " ";
            }
            message += "\n";
            showRichTextBox.Text = message;

        }

        private void MaxMinButton_Click(object sender, EventArgs e)
        {
            int maxNumber;
            int minNumber;
            string message = "";
            message += Display("The values stored into the List are");
            maxNumber = minNumber = numbers[0];
            foreach(int number in numbers)
            {
                if(number>maxNumber)
                {
                    maxNumber = number;
                } 
                if(number<minNumber)
                {
                    minNumber = number;
                }
            }
            message += "Maximum element is : " + maxNumber;
            message += "\n";
            message += "Minimum element is : " + minNumber;
            showRichTextBox.Text = message;
        }

        private void OddEvenButton_Click(object sender, EventArgs e)
        {
            string odd="";
            string even="";
            string message = "";
            message += Display("The values stored into the List are");
            foreach(int number in numbers)
            {
                if(number%2==0)
                {
                    even += number + " ";
                }
                else
                {
                    odd += number + " ";
                }
            }
            message += "The Even elements are: \n";
            message += even + "\n";
            message += "The Odd elements are: \n";
            message += odd;
            showRichTextBox.Text = message;
        }
    }
}
