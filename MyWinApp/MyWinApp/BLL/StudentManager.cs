using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using MyWinApp.Repository;
using MyWinApp.Models;

namespace MyWinApp.BLL
{
    public class StudentManager
    {
        StudentRepository _studentRepository = new StudentRepository();
        public DataTable LoadDistrict()
        {
            return _studentRepository.LoadDistrict();
        }
        public DataTable ShowStudents()
        {
            return _studentRepository.ShowStudents();
        }
        public void InsertStudent(Student student)
        {
             _studentRepository.InsertStudent(student);
        }
    }
    

}
