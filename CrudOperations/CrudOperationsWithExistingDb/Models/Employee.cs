using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudOperationsWithExistingDb.Models
{
    public partial class Employee
    {
        public int PkemployeeId { get; set; }
        public int FkdeptId { get; set; }
        public string EmployeeName { get; set; }
        public decimal EmployeeSalary { get; set; }
        //[StringLength(250)]
        public string EmployeeAddress { get; set; }
        public bool IsActive { get; set; }

        public virtual Department Fkdept { get; set; }
    }
}
