using System;
using System.Collections.Generic;

#nullable disable

namespace LabExercise8.Models
{
    public partial class InternalCandidate
    {
        public string CCandidateCode { get; set; }
        public string CEmployeeCode { get; set; }
        public string CInternalJobPostingCode { get; set; }
        public string CPositionCodeAppliedFor { get; set; }
        public DateTime? DDateOfApplication { get; set; }
        public DateTime? DTestDate { get; set; }
        public short? SiTestScore { get; set; }
        public DateTime? DInterviewDate { get; set; }
        public string CInterviewer { get; set; }
        public string VInterviewComments { get; set; }
        public string CRating { get; set; }
        public string CStatus { get; set; }

        public virtual InternalJobPosting CInternalJobPostingCodeNavigation { get; set; }
        public virtual Position CPositionCodeAppliedForNavigation { get; set; }
    }
}
