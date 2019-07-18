using MyMVCApp.DatabaseContext.DatabaseContext;
using MyMVCApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMVCApp.Repository.Repository
{
    public class StudentRepository
    {
        Student _student;
        StudentDbContext db;
        public StudentRepository()
        {
            db = new StudentDbContext();
        }
        public void Add(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }
        public void Delete(Student student)
        {
            Student aStudent = db.Students.FirstOrDefault(c => c.ID == student.ID);
            if(aStudent!=null)
            {
                db.Students.Remove(aStudent);
                db.SaveChanges();
            }
        }
        public void Update(Student student)
        {
            db.Entry(student).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();  
        } 
        public List<Student> GetStudents()
        {
            return db.Students.ToList();
        } 
        public Student GetById(Student student)
        {
            Student aStudent = db.Students.FirstOrDefault(c => c.ID == student.ID);
            if(aStudent!=null)
            {
                return aStudent;
            } 
            else
            {
                return null;
            }
        }
    }
}
