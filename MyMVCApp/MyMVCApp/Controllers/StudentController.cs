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
        public ActionResult Add()
        {
            _student = new Student();
            _student.ID = 2;
            _student.Name = "Sayed";
            _studentManager.Add(_student);
            return View();
        }
        public ActionResult Delete()
        {
            _student = new Student();
            _student.ID = 3;
            _studentManager.Delete(_student);
            return View();
        } 
        public ActionResult Update()
        {
            _student = new Student();
            _student.ID = 4;
            Student aStudent = _studentManager.GetById(_student);
            _student.Name = "jamal";
            if(aStudent!=null)
            {
                aStudent.Name = _student.Name;
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