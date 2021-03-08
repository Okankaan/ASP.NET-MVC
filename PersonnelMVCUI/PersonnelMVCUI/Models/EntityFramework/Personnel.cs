//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersonnelMVCUI.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Personnel
    {
        public int Id { get; set; }
        [Display(Name = "Department Name")]//For UI showing
        [Required(ErrorMessage = "The Department Name field is required...")]
        public Nullable<int> DepartmentId { get; set; }
        [Required(ErrorMessage = "The Name field is required...")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Surname field is required...")]
        public string Surname { get; set; }
        [Display(Name = "Salary")]
        [Required(ErrorMessage = "The Salary field is required...")]
        [Range(1399, 20000, ErrorMessage = "The Salary field must be between 1399 and 20000...")]
        public Nullable<short> Salary { get; set; }
        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "The Birth Date field is required...")]
        public Nullable<System.DateTime> BirthDate { get; set; }
        [Required(ErrorMessage = "The Gender field is required...")]
        public bool Gender { get; set; }
        [Display(Name = "Marriage Status")]
        public bool IsMarried { get; set; }

        public virtual Department Department { get; set; }
    }
}
