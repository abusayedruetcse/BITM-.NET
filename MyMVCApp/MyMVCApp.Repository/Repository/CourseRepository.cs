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
    }
}
