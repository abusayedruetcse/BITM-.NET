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
    }
}