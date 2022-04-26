using System;
using System.Collections.Generic;

#nullable disable

namespace LabExercise8.Models
{
    public partial class PositionSkill
    {
        public string CPositionCode { get; set; }
        public string CSkillCode { get; set; }

        public virtual Position CPositionCodeNavigation { get; set; }
        public virtual Skill CSkillCodeNavigation { get; set; }
    }
}
