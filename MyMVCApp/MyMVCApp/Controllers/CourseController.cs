using MyMVCApp.BLL.BLL;
using MyMVCApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVCApp.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        CourseManager _courseManager = new CourseManager();
        public ActionResult Add(Course course)
        {
            _courseManager.Add(course);
            return View();
        } 
        public ActionResult Update(Course course)
        {
            var aCourse = _courseManager.GetById(course);
            if(aCourse!=null)
            {
                aCourse.Name = course.Name;
                _courseManager.Update(aCourse);
            }            
            return View();
        }

    }
}