using ClassLibApp.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibApp
{
    public partial class StudentUi : Form
    {
        Student student = new Student();
        public StudentUi()
        {
            InitializeComponent();
        }

        private void StudentUi_Load(object sender, EventArgs e)
        {
            student.Name = "Fatima";
            student.Roll = "12345";
            displayRichTextBox.Text = "Name: " + student.Name + Environment.NewLine + "Roll: " + student.Roll;
        }
    }
}
