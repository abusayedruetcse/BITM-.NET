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
    public partial class FireRangeAutomationSystem : Form
    {
        List<string> soldierNos = new List<string>();
        List<string> soldierNames = new List<string>();
        List<int> target1Scores = new List<int>();
        List<int> target2Scores = new List<int>();
        List<int> target3Scores = new List<int>();
        List<int> target4Scores = new List<int>();
        List<double> averageScores = new List<double>();
        List<int> totalScores = new List<int>();

        public FireRangeAutomationSystem()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string soldierNo;
                string soldierName;
                int target1Score;
                int target2Score;
                int target3Score;
                int target4Score;
                int sumOfScore;
                soldierNo = soldierNoTextBox.Text;
                if (String.IsNullOrEmpty(soldierNo))
                {
                    MessageBox.Show("Your Solder No is Empty, Please Enter");
                    return;
                }
                if (isExist(soldierNo))
                {
                    MessageBox.Show("Soldier Already Exists!");
                    return;
                }
                soldierName = soldierNameTextBox.Text;
                if (String.IsNullOrEmpty(soldierName))
                {
                    MessageBox.Show("Your Solder Name is Empty, Please Enter");
                    return;
                }

                if (String.IsNullOrEmpty(target1TextBox.Text))
                {
                    MessageBox.Show("Target 1 Score is Empty, Please Enter");
                    return;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(target1TextBox.Text, "[^0-9]"))
                {
                    MessageBox.Show("Enter Numeric Number for Target 1 socre!");
                    return;
                }
                target1Score = Convert.ToInt32(target1TextBox.Text);
                if (String.IsNullOrEmpty(target2TextBox.Text))
                {
                    MessageBox.Show("Target 2 Score is Empty, Please Enter");
                    return;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(target2TextBox.Text, "[^0-9]"))
                {
                    MessageBox.Show("Enter Numeric Number for Target 2 socre!");
                    return;
                }
                target2Score = Convert.ToInt32(target2TextBox.Text);
                if (String.IsNullOrEmpty(target3TextBox.Text))
                {
                    MessageBox.Show("Target 3 Score is Empty, Please Enter");
                    return;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(target3TextBox.Text, "[^0-9]"))
                {
                    MessageBox.Show("Enter Numeric Number for Target 3 socre!");
                    return;
                }
                target3Score = Convert.ToInt32(target3TextBox.Text);
                if (String.IsNullOrEmpty(target4TextBox.Text))
                {
                    MessageBox.Show("Target 4 Score is Empty, Please Enter");
                    return;
                }
                if (System.Text.RegularExpressions.Regex.IsMatch(target4TextBox.Text, "[^0-9]"))
                {
                    MessageBox.Show("Enter Numeric Number for Target 4 socre!");
                    return;
                }
                target4Score = Convert.ToInt32(target4TextBox.Text);

                soldierNos.Add(soldierNo);
                soldierNames.Add(soldierName);
                target1Scores.Add(target1Score);
                target2Scores.Add(target2Score);
                target3Scores.Add(target3Score);
                target4Scores.Add(target4Score);
                sumOfScore = target1Score + target2Score + target3Score + target4Score;
                totalScores.Add(sumOfScore);
                averageScores.Add((double)(sumOfScore) / 4);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }
        private bool isExist(string checkSoldierNo)
        {
            bool isDuplicate = false;
            foreach(string soldierNo in soldierNos)
            {
                if(soldierNo==checkSoldierNo)
                {
                    isDuplicate = true;
                    break;
                }
            }
            return isDuplicate;

        }

        private void ShowAllButton_Click(object sender, EventArgs e)
        {
            string message = "";
            message += "Soldier No.\tSoldier Name\tAverage Score\tTotal Score\n";           
            for(int index=0; index<soldierNos.Count; index++)
            {                             
                message += soldierNos[index]+"\t"+soldierNames[index]+"\t"+averageScores[index]+"\t"+totalScores[index]+"\n";
            }
            showRichTextBox.Text = message;
           
            int topAverageIndex = averageScores.IndexOf(averageScores.Max());
            topAverageTextBox.Text = soldierNames[topAverageIndex];
            int topTotalIndex = totalScores.IndexOf(totalScores.Max());
            topTotalTextBox.Text = soldierNames[topTotalIndex];

        }
    }
}
