﻿using MyMVCApp.Models.Models;
using MyMVCApp.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMVCApp.BLL.BLL
{
    public class StudentManager
    {
        Student _student;
        StudentRepository _studentRepository;
        public StudentManager()
        {
            _studentRepository = new StudentRepository();
        }
        public void Add(Student student)
        {           
            _studentRepository.Add(student);
        }
    }
}