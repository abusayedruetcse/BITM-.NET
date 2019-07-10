using ClassLibApp.BLL.BLL;
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
        StudentManager _studentManager = new StudentManager();
        public StudentUi()
        {
            InitializeComponent();
        }

        private void StudentUi_Load(object sender, EventArgs e)
        {
            string Name = "Fatima";
            string Roll = "12345";
            displayRichTextBox.Text = _studentManager.AddStudent(Name, Roll);
        }
    }
}
