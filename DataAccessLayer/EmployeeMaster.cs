using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataAccessLayer
{
    public class EmployeeMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "EmpId")]
        public long EmpId { get; set; }

        [Display(Name = "EmpName")]
        public string EmpName { get; set; }

        [Display(Name = "Designation")]
        public string Designation { get; set; }

        [Display(Name = "DOB")]
        public Nullable<DateTime> DOB { get; set; }

        [Display(Name = "DepartmentId")]
        public int DepartmentId { get; set; }

        [NotMapped]
        [Display(Name = "Department")]
        public string Department { get; set; }

    }
}