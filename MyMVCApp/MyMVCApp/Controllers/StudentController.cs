using MyMVCApp.BLL.BLL;
using MyMVCApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCApp.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        Student _student;
        StudentManager _studentManager;
        public StudentController()
        {
            _studentManager = new StudentManager();
        }
        public ActionResult Add(Student student)
        {            
            _studentManager.Add(student);
            return View();
        }
        public ActionResult Delete(Student student)
        {            
            _studentManager.Delete(student);
            return View();
        } 
        public ActionResult Update(Student student)
        {            
            Student aStudent = _studentManager.GetById(student);           
            if(aStudent!=null)
            {
                aStudent.Name = student.Name;
                _studentManager.Update(aStudent);
            }           
            return View();
        } 
        public ActionResult GetStudents()
        {
            List<Student> listOfStudent;
            listOfStudent = _studentManager.GetStudents();
            return View();
        } 
        public ActionResult GetById()
        {
            _student = new Student();
            _student.ID = 4;
            Student aStudent;
            aStudent = _studentManager.GetById(_student);
            return View();
        }
    }
}