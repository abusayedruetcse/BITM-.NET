using ClassLibApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibApp.BLL.BLL
{    
    public class StudentManager
    {
        Student student;
        public StudentManager()
        {
            student = new Student();
        }
        public string AddStudent(string name, string roll)
        {
            student.Name = name;
            student.Roll = roll;
            return "Name: " + student.Name + Environment.NewLine + "Roll: " + student.Roll;
        }
    }
}
