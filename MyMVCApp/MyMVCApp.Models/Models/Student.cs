using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMVCApp.Models.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Enter Name")]
        [StringLength(50,MinimumLength =3)]
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        [NotMapped]
        public List<Student> Students { get; set; }
    }
}
