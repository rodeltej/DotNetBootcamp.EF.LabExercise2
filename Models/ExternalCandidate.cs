using System;
using System.Collections.Generic;

#nullable disable

namespace LabExercise8.Models
{
    public partial class ExternalCandidate
    {
        public ExternalCandidate()
        {
            CandidateSkills = new HashSet<CandidateSkill>();
            EmployeeReferrals = new HashSet<EmployeeReferral>();
        }

        public string CCandidateCode { get; set; }
        public string VFirstName { get; set; }
        public string VLastName { get; set; }
        public string VAddress { get; set; }
        public string CCity { get; set; }
        public string CState { get; set; }
        public string CZip { get; set; }
        public string CCountryCode { get; set; }
        public string CPhone { get; set; }
        public string CPositionCode { get; set; }
        public DateTime? DDateOfApplication { get; set; }
        public string CEmployeeReferralNo { get; set; }
        public string CNewsAdNo { get; set; }
        public string CAgencyCode { get; set; }
        public string CContractRecruiterCode { get; set; }
        public string CJobFairCode { get; set; }
        public string CCampusRecruitmentCode { get; set; }
        public string CExEmployeeCode { get; set; }
        public string VQualification { get; set; }
        public short? SiPrevWorkExperience { get; set; }
        public DateTime? DBirthDate { get; set; }
        public string CSex { get; set; }
        public string CCollegeCode { get; set; }
        public decimal? MPrevAnnualSalary { get; set; }
        public byte[] ImPhotograph { get; set; }
        public string VEmailId { get; set; }
        public string CStatus { get; set; }
        public DateTime? DTestDate { get; set; }
        public short? SiTestScore { get; set; }
        public DateTime? DInterviewDate { get; set; }
        public string CInterviewer { get; set; }
        public string VInterviewComments { get; set; }
        public string CRating { get; set; }

        public virtual RecruitmentAgency CAgencyCodeNavigation { get; set; }
        public virtual CampusRecruitment CCampusRecruitmentCodeNavigation { get; set; }
        public virtual ContractRecruiter CContractRecruiterCodeNavigation { get; set; }
        public virtual Country CCountryCodeNavigation { get; set; }
        public virtual JobFair CJobFairCodeNavigation { get; set; }
        public virtual NewsAd CNewsAdNoNavigation { get; set; }
        public virtual Position CPositionCodeNavigation { get; set; }
        public virtual ICollection<CandidateSkill> CandidateSkills { get; set; }
        public virtual ICollection<EmployeeReferral> EmployeeReferrals { get; set; }
    }
}
