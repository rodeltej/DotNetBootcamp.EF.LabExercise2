using System;
using System.Collections.Generic;

#nullable disable

namespace LabExercise8.Models
{
    public partial class EmployeeSkill
    {
        public string CEmployeeCode { get; set; }
        public string CSkillCode { get; set; }

        public virtual Employee CEmployeeCodeNavigation { get; set; }
        public virtual Skill CSkillCodeNavigation { get; set; }
    }
}
