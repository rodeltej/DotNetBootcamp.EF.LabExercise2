using System;
using System.Collections.Generic;

#nullable disable

namespace LabExercise8.Models
{
    public partial class JobFair
    {
        public JobFair()
        {
            ExternalCandidates = new HashSet<ExternalCandidate>();
        }

        public string CJobFairCode { get; set; }
        public string VLocation { get; set; }
        public string VJobFairCompany { get; set; }
        public decimal? MFee { get; set; }
        public DateTime? DFairDate { get; set; }

        public virtual ICollection<ExternalCandidate> ExternalCandidates { get; set; }
    }
}
