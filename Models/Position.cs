using System;
using System.Collections.Generic;

#nullable disable

namespace LabExercise8.Models
{
    public partial class Position
    {
        public Position()
        {
            ExternalCandidates = new HashSet<ExternalCandidate>();
            InternalCandidates = new HashSet<InternalCandidate>();
            PositionSkills = new HashSet<PositionSkill>();
            Requisitions = new HashSet<Requisition>();
        }

        public string CPositionCode { get; set; }
        public string VDescription { get; set; }
        public int? IBudgetedStrength { get; set; }
        public short? SiYear { get; set; }
        public int? ICurrentStrength { get; set; }

        public virtual ICollection<ExternalCandidate> ExternalCandidates { get; set; }
        public virtual ICollection<InternalCandidate> InternalCandidates { get; set; }
        public virtual ICollection<PositionSkill> PositionSkills { get; set; }
        public virtual ICollection<Requisition> Requisitions { get; set; }
    }
}
