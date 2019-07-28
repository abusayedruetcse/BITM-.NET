using MyMVCApp.Models.Models;
using MyMVCApp.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMVCApp.BLL.BLL
{
    public class CourseManager
    {
        CourseRepository _courseRepository;
        public CourseManager()
        {
            _courseRepository = new CourseRepository();
        }
        public void Add(Course course)
        {
            _courseRepository.Add(course);
        }
        public void Update(Course course)
        {
            _courseRepository.Update(course);
        }
        public Course GetById(Course course)
        {
            return _courseRepository.GetById(course);
        }
    }
}
