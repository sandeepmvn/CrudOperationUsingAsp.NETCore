using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperationUsingCF.Models
{
    //[Table("tblEmployee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public decimal EmployeeSalary { get; set; }
        [Required]
        public bool IsActive { get; set; }

        //[ForeignKey("Department")]
        public int FKDeptId { get; set; }
        public Department Department { get; set; }

    }

    //[Column("EmpName")]
}
