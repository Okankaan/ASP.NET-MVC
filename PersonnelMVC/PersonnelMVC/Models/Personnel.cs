using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonnelMVC.Models
{
    public class Personnel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
    }
}