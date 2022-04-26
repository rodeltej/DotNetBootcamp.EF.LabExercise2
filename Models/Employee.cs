using System;
using System.Collections.Generic;

#nullable disable

namespace LabExercise8.Models
{
    public partial class Employee
    {
        public Employee()
        {
            AnnualSalaries = new HashSet<AnnualSalary>();
            EmployeeReferrals = new HashSet<EmployeeReferral>();
            EmployeeSkills = new HashSet<EmployeeSkill>();
            MonthlySalaries = new HashSet<MonthlySalary>();
        }

        public string CEmployeeCode { get; set; }
        public string VFirstName { get; set; }
        public string VLastName { get; set; }
        public string CCandidateCode { get; set; }
        public string VAddress { get; set; }
        public string CCity { get; set; }
        public string CState { get; set; }
        public string CZip { get; set; }
        public string CCountryCode { get; set; }
        public string CPhone { get; set; }
        public string VQualification { get; set; }
        public DateTime? DBirthDate { get; set; }
        public string CSex { get; set; }
        public string CCurrentPosition { get; set; }
        public string CDesignation { get; set; }
        public string CEmailId { get; set; }
        public string CDepartmentCode { get; set; }
        public string CRegion { get; set; }
        public byte[] ImPhoto { get; set; }
        public DateTime? DJoiningDate { get; set; }
        public DateTime? DResignationDate { get; set; }
        public string CSocialSecurityNo { get; set; }
        public string CSupervisorCode { get; set; }

        public virtual Country CCountryCodeNavigation { get; set; }
        public virtual Department CDepartmentCodeNavigation { get; set; }
        public virtual ICollection<AnnualSalary> AnnualSalaries { get; set; }
        public virtual ICollection<EmployeeReferral> EmployeeReferrals { get; set; }
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
        public virtual ICollection<MonthlySalary> MonthlySalaries { get; set; }
    }
}
