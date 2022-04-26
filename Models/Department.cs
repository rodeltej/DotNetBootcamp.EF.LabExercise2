using System;
using System.Collections.Generic;

#nullable disable

namespace LabExercise8.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public string CDepartmentCode { get; set; }
        public string VDepartmentName { get; set; }
        public string VDepartmentHead { get; set; }
        public string VLocation { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
