using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataAccessLayer
{
    public class DepartmentMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "DepartmentId")]
        public int DepartmentId { get; set; }

        [Display(Name = "Department")]
        public string Department { get; set; }
    }
}