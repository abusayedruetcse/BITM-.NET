using MyMVCApp.Models.Models;
using MyMVCApp.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMVCApp.BLL.BLL
{
    public class StudentManager
    {
        Student _student;
        StudentRepository _studentRepository;
        public StudentManager()
        {
            _studentRepository = new StudentRepository();
        }
        public bool Add(Student student)
        {           
            return _studentRepository.Add(student);
        }
        public bool Delete(Student student)
        {
            return _studentRepository.Delete(student);
        }
        public bool Update(Student student)
        {
            return _studentRepository.Update(student);
        }
        public List<Student> GetStudents()
        {
            return _studentRepository.GetStudents();
        }
        public Student GetById(Student student)
        {
            return _studentRepository.GetById(student);
        }
    }
}
