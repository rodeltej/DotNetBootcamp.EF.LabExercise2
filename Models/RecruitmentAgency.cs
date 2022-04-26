using System;
using System.Collections.Generic;

#nullable disable

namespace LabExercise8.Models
{
    public partial class RecruitmentAgency
    {
        public RecruitmentAgency()
        {
            ExternalCandidates = new HashSet<ExternalCandidate>();
        }

        public string CAgencyCode { get; set; }
        public string CName { get; set; }
        public string VAddress { get; set; }
        public string CCity { get; set; }
        public string CState { get; set; }
        public string CZip { get; set; }
        public string CPhone { get; set; }
        public string CFax { get; set; }
        public short? SiPercentageCharge { get; set; }
        public decimal? MTotalPaid { get; set; }

        public virtual ICollection<ExternalCandidate> ExternalCandidates { get; set; }
    }
}
