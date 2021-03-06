﻿using ClassLibApp.Models.Models;
using ClassLibApp.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibApp.BLL.BLL
{    
    public class StudentManager
    {
        Student student;
        StudentRepository _studentRepository;
        public StudentManager()
        {
            student = new Student();
            _studentRepository = new StudentRepository();
        }
        public string AddStudent(string name, string roll)
        {
            return _studentRepository.AddStudent(name, roll);
        }
    }
}
