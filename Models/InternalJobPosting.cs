using System;
using System.Collections.Generic;

#nullable disable

namespace LabExercise8.Models
{
    public partial class InternalJobPosting
    {
        public InternalJobPosting()
        {
            InternalCandidates = new HashSet<InternalCandidate>();
        }

        public string CInternalJobPostingCode { get; set; }
        public string CPositionCode { get; set; }
        public short SiNoOfVacancies { get; set; }
        public string VRegion { get; set; }
        public DateTime DNoticeReleaseDate { get; set; }
        public DateTime? DDeadline { get; set; }

        public virtual ICollection<InternalCandidate> InternalCandidates { get; set; }
    }
}
