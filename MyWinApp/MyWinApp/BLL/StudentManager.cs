using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using MyWinApp.Repository;

namespace MyWinApp.BLL
{
    public class StudentManager
    {
        StudentRepository _studentRepository = new StudentRepository();
        public DataTable LoadDistrict()
        {
            return _studentRepository.LoadDistrict();
        }
    }
}
