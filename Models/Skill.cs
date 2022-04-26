using System;
using System.Collections.Generic;

#nullable disable

namespace LabExercise8.Models
{
    public partial class Skill
    {
        public Skill()
        {
            CandidateSkills = new HashSet<CandidateSkill>();
            EmployeeSkills = new HashSet<EmployeeSkill>();
            PositionSkills = new HashSet<PositionSkill>();
        }

        public string CSkillCode { get; set; }
        public string VSkill { get; set; }

        public virtual ICollection<CandidateSkill> CandidateSkills { get; set; }
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
        public virtual ICollection<PositionSkill> PositionSkills { get; set; }
    }
}
