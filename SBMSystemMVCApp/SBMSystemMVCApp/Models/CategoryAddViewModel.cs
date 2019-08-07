﻿using SBMSystemMVCApp.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SBMSystemMVCApp.Models
{
    public class CategoryAddViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Code is Empty")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Code is Empty")]
        public string Name { get; set; }
        public List<Category> Categories { get; set; }
    }
}