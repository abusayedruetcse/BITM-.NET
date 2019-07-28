using MyMVCApp.DatabaseContext.DatabaseContext;
using MyMVCApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMVCApp.Repository.Repository
{
    public class CourseRepository
    {
        StudentDbContext db;
        public CourseRepository()
        {
            db = new StudentDbContext();
        }
        public void Add(Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();
        } 
        public void Update(Course course)
        {
            db.Entry(course).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public Course GetById(Course course)
        {
            var aCourse = db.Courses.FirstOrDefault(c => c.ID == course.ID);
            if(aCourse!=null)
            {
                return aCourse;
            }
            return null;
        }
    }
}
