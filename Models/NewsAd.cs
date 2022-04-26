using System;
using System.Collections.Generic;

#nullable disable

namespace LabExercise8.Models
{
    public partial class NewsAd
    {
        public NewsAd()
        {
            ExternalCandidates = new HashSet<ExternalCandidate>();
        }

        public string CNewsAdNo { get; set; }
        public string CNewspaperCode { get; set; }
        public DateTime? DAdStartDate { get; set; }
        public DateTime? DDeadline { get; set; }

        public virtual Newspaper CNewspaperCodeNavigation { get; set; }
        public virtual ICollection<ExternalCandidate> ExternalCandidates { get; set; }
    }
}
