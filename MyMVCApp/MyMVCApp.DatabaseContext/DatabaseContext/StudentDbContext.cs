using MyMVCApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMVCApp.DatabaseContext.DatabaseContext
{
    public class StudentDbContext:DbContext 
    {
        DbSet<Student> Students;

    }
}
