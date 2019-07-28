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
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Student student)
        {            
            if(ModelState.IsValid)
            {
                if(_studentManager.Add(student))
                {
                    ViewBag.SuccessMsg = "Saved Successfully";
                }
                else
                {
                    ViewBag.FailMsg = "Save Failed";
                }
            } 
            else
            {
                ViewBag.FailMsg = "Validation Error";
            }
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
        public ActionResult Show(Student student)
        {
            var students = _studentManager.GetStudents();
            if(student.Name!=null)
            {
               students = students.Where(s => s.Name.ToLower().Contains(student.Name.ToLower())).ToList();
            } 
            if(student.Address!=null)
            {
                students = students.Where(s => s.Address.ToLower().Contains(student.Address.ToLower())).ToList();
            }
            if(student.Age>0)
            {
                students = students.Where(s => s.Age == student.Age).ToList();
            }
            student.Students = students;
            return View(student);
        }
    }
}