using System;
using System.Collections.Generic;

#nullable disable

namespace LabExercise8.Models
{
    public partial class Country
    {
        public Country()
        {
            Employees = new HashSet<Employee>();
            ExternalCandidates = new HashSet<ExternalCandidate>();
            Newspapers = new HashSet<Newspaper>();
        }

        public string CCountryCode { get; set; }
        public string CCountry { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<ExternalCandidate> ExternalCandidates { get; set; }
        public virtual ICollection<Newspaper> Newspapers { get; set; }
    }
}
