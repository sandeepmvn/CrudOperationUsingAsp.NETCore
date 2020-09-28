using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperationUsingCF.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        public string DepartmentName { get; set; }

        public bool IsActive { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
