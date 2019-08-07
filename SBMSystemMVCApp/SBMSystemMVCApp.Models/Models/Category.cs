using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBMSystemMVCApp.Models.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Code is Empty")]        
        public string Code { get; set; }
        [Required(ErrorMessage = "Code is Empty")]
        public string Name { get; set; }
    }
}
