using System;
using System.Collections.Generic;

namespace CrudOperationsWithExistingDb.Models
{
    public partial class Employee
    {
        public int PkemployeeId { get; set; }
        public int FkdeptId { get; set; }
        public string EmployeeName { get; set; }
        public decimal EmployeeSalary { get; set; }
        public bool IsActive { get; set; }

        public virtual Department Fkdept { get; set; }
    }
}
