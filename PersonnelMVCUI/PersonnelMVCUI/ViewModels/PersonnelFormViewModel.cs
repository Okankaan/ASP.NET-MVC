using PersonnelMVCUI.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonnelMVCUI.ViewModels
{
    public class PersonnelFormViewModel
    {
        public IEnumerable<Department> Departments { get; set; }
        public Personnel Personnel { get; set; }
    }
}