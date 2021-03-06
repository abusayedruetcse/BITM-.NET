﻿using MyMVCApp.DatabaseContext.DatabaseContext;
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
        public bool Add(Student student)
        {
            int isExecuted = 0;
            db.Students.Add(student);
            isExecuted=db.SaveChanges();
            return isExecuted > 0;
        }
        public bool Delete(Student student)
        {
            int isExecuted = 0;
            Student aStudent = db.Students.FirstOrDefault(c => c.ID == student.ID);
            if(aStudent!=null)
            {
                db.Students.Remove(aStudent);
                isExecuted = db.SaveChanges();
            }
            return isExecuted > 0;
        }
        public bool Update(Student student)
        {
            int isExecuted = 0;
            db.Entry(student).State = System.Data.Entity.EntityState.Modified;
            isExecuted = db.SaveChanges();
            return isExecuted > 0;
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
