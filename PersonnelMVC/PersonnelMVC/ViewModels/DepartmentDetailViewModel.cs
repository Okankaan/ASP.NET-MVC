using PersonnelMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonnelMVC.ViewModels
{
    public class DepartmentDetailViewModel
    {
        public Department Department { get; set; }
        public List<Personnel> Personnels { get; set; }
    }
}