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

        private void DuplicateButton_Click(object sender, EventArgs e)
        {
            string duplicate = "";
            bool[] isDone = new bool[size];
            bool isDuplicate;
            string message = "";
            message += Display("The elements stored in the first array are");
            message += "The duplicate elements are:\n";
            for (int firstIndex=0; firstIndex < count; firstIndex++)
            {
                isDuplicate = false;
                if(!isDone[firstIndex])
                {
                    isDone[firstIndex] = true;
                    for(int secondIndex=0; secondIndex<count; secondIndex++)
                    {
                        if(!isDone[secondIndex])
                        {
                            if(numbers[firstIndex]==numbers[secondIndex])
                            {
                                isDuplicate = true;
                                isDone[secondIndex] = true;
                            }
                        }
                    }
                }
                if(isDuplicate)
                {
                    duplicate += numbers[firstIndex] + " ";
                }
            }
            message += duplicate;
            showRichTextBox.Text = message;
        }

        private void UniqueButton_Click(object sender, EventArgs e)
        {
            bool isUnique;
            string unique="";
            string message = "";
            message += Display("The elements stored in the first array are");
            message += "The unique elements are:\n";
            for(int firstIndex=0; firstIndex<count; firstIndex++)
            {
                isUnique = true;
                for(int secondIndex=0; secondIndex<count; secondIndex++)
                {
                    if(numbers[firstIndex]==numbers[secondIndex]&& firstIndex!=secondIndex)
                    {
                        isUnique = false;
                        break;
                    }
                }
                if(isUnique)
                {
                    unique += numbers[firstIndex]+" ";
                }
            }
            message += unique;
            showRichTextBox.Text = message;
        }

        private void MaxMinButton_Click(object sender, EventArgs e)
        {
            int maxNumber;
            int minNumber;
            string message = "";
            message += Display("The values store into the array are");
            maxNumber = minNumber = numbers[0];
            for(int index=0; index<count; index++)
            {
                if(numbers[index]>maxNumber)
                {
                    maxNumber = numbers[index];
                }
                if(numbers[index]<minNumber)
                {
                    minNumber = numbers[index];
                }
            }
            message += "Maximum element is : "+maxNumber;
            message += "\n";
            message += "Minimum element is : " + minNumber;

            showRichTextBox.Text = message;
        }

        private void OddEvenButton_Click(object sender, EventArgs e)
        {
            string odd = "";
            string even = "";
            string message = "";
            message += Display("The values store into the array are");
            for(int index=0; index<count; index++)
            {
                if(numbers[index]%2==0)
                {
                    even += numbers[index] + " ";
                }
                else
                {
                    odd += numbers[index] + " ";
                }
            }
            message += "The Even elements are: \n";
            message += even;
            message += "\n";
            message += "The Odd elements are : \n";
            message += odd;
            showRichTextBox.Text = message;
        }
    }
}
