using System;
using System.Collections.Generic;

namespace CrudOperationsWithExistingDb.Models
{
    public partial class Department
    {
        public Department()
        {
            Employee = new HashSet<Employee>();
        }

        public int PkdepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
