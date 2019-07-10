using ClassLibApp.BLL.BLL;
using ClassLibApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            StudentManager _studentManager = new StudentManager();
            string Name = "Fatima";
            string Roll = "12345";
            Console.WriteLine(_studentManager.AddStudent(Name, Roll));
            Console.ReadKey();
        }
    }
}
