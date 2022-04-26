using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LabExercise8.Models;

#nullable disable

namespace LabExercise8.Data
{
    public partial class RecruitmentContext : DbContext
    {
        public string DbConnection { get; set; }
        public RecruitmentContext(string dbConnection)
        {
            DbConnection = dbConnection;
        }


        public virtual DbSet<AnnualSalary> AnnualSalaries { get; set; }
        public virtual DbSet<CampusRecruitment> CampusRecruitments { get; set; }
        public virtual DbSet<CandidateSkill> CandidateSkills { get; set; }
        public virtual DbSet<College> Colleges { get; set; }
        public virtual DbSet<ContractRecruiter> ContractRecruiters { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeReferral> EmployeeReferrals { get; set; }
        public virtual DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public virtual DbSet<ExternalCandidate> ExternalCandidates { get; set; }
        public virtual DbSet<InternalCandidate> InternalCandidates { get; set; }
        public virtual DbSet<InternalJobPosting> InternalJobPostings { get; set; }
        public virtual DbSet<JobFair> JobFairs { get; set; }
        public virtual DbSet<MonthlySalary> MonthlySalaries { get; set; }
        public virtual DbSet<NewsAd> NewsAds { get; set; }
        public virtual DbSet<Newspaper> Newspapers { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<PositionSkill> PositionSkills { get; set; }
        public virtual DbSet<RecruitmentAgency> RecruitmentAgencies { get; set; }
        public virtual DbSet<Recruitmentuser> Recruitmentusers { get; set; }
        public virtual DbSet<Requisition> Requisitions { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AnnualSalary>(entity =>
            {
                entity.HasKey(e => new { e.CEmployeeCode, e.SiYear })
                    .HasName("ast_pk");

                entity.ToTable("AnnualSalary");

                entity.Property(e => e.CEmployeeCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cEmployeeCode")
                    .IsFixedLength(true);

                entity.Property(e => e.SiYear).HasColumnName("siYear");

                entity.Property(e => e.MAnnualSalary)
                    .HasColumnType("money")
                    .HasColumnName("mAnnualSalary");

                entity.HasOne(d => d.CEmployeeCodeNavigation)
                    .WithMany(p => p.AnnualSalaries)
                    .HasForeignKey(d => d.CEmployeeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AnnualSal__cEmpl__5441852A");
            });

            modelBuilder.Entity<CampusRecruitment>(entity =>
            {
                entity.HasKey(e => e.CCampusRecruitmentCode)
                    .HasName("cr_pk");

                entity.ToTable("CampusRecruitment");

                entity.Property(e => e.CCampusRecruitmentCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cCampusRecruitmentCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CCollegeCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cCollegeCode")
                    .IsFixedLength(true);

                entity.Property(e => e.DRecruitmentEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dRecruitmentEndDate");

                entity.Property(e => e.DRecruitmentStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dRecruitmentStartDate");

                entity.HasOne(d => d.CCollegeCodeNavigation)
                    .WithMany(p => p.CampusRecruitments)
                    .HasForeignKey(d => d.CCollegeCode)
                    .HasConstraintName("FK__CampusRec__cColl__4222D4EF");
            });

            modelBuilder.Entity<CandidateSkill>(entity =>
            {
                entity.HasKey(e => new { e.CCandidateCode, e.CSkillCode })
                    .HasName("sctv_pk");

                entity.ToTable("CandidateSkill");

                entity.Property(e => e.CCandidateCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cCandidateCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CSkillCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cSkillCode")
                    .IsFixedLength(true);

                entity.HasOne(d => d.CCandidateCodeNavigation)
                    .WithMany(p => p.CandidateSkills)
                    .HasForeignKey(d => d.CCandidateCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Candidate__cCand__6E01572D");

                entity.HasOne(d => d.CSkillCodeNavigation)
                    .WithMany(p => p.CandidateSkills)
                    .HasForeignKey(d => d.CSkillCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Candidate__cSkil__6EF57B66");
            });

            modelBuilder.Entity<College>(entity =>
            {
                entity.HasKey(e => e.CCollegeCode)
                    .HasName("ct_pk");

                entity.ToTable("College");

                entity.Property(e => e.CCollegeCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cCollegeCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CCity)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cCity")
                    .IsFixedLength(true);

                entity.Property(e => e.CCollegeName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cCollegeName")
                    .IsFixedLength(true);

                entity.Property(e => e.CPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cPhone")
                    .IsFixedLength(true);

                entity.Property(e => e.CState)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cState")
                    .IsFixedLength(true);

                entity.Property(e => e.CZip)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cZip")
                    .IsFixedLength(true);

                entity.Property(e => e.VCollegeAddress)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("vCollegeAddress");
            });

            modelBuilder.Entity<ContractRecruiter>(entity =>
            {
                entity.HasKey(e => e.CContractRecruiterCode)
                    .HasName("crtp_pk");

                entity.ToTable("ContractRecruiter");

                entity.Property(e => e.CContractRecruiterCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cContractRecruiterCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CCity)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cCity")
                    .IsFixedLength(true);

                entity.Property(e => e.CFax)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cFax")
                    .IsFixedLength(true);

                entity.Property(e => e.CName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("cName")
                    .IsFixedLength(true);

                entity.Property(e => e.CPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cPhone")
                    .IsFixedLength(true);

                entity.Property(e => e.CState)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cState")
                    .IsFixedLength(true);

                entity.Property(e => e.CZip)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cZip")
                    .IsFixedLength(true);

                entity.Property(e => e.MTotalPaid)
                    .HasColumnType("money")
                    .HasColumnName("mTotalPaid");

                entity.Property(e => e.SiPercentageCharge).HasColumnName("siPercentageCharge");

                entity.Property(e => e.VAddress)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("vAddress");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CCountryCode)
                    .HasName("c_pk");

                entity.ToTable("Country");

                entity.Property(e => e.CCountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("cCountryCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CCountry)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("cCountry")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.CDepartmentCode)
                    .HasName("dt_pk");

                entity.ToTable("Department");

                entity.Property(e => e.CDepartmentCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cDepartmentCode")
                    .IsFixedLength(true);

                entity.Property(e => e.VDepartmentHead)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("vDepartmentHead");

                entity.Property(e => e.VDepartmentName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("vDepartmentName");

                entity.Property(e => e.VLocation)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vLocation");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.CEmployeeCode)
                    .HasName("etv_pk");

                entity.ToTable("Employee");

                entity.HasIndex(e => e.CSocialSecurityNo, "UQ__Employee__6AB6057F8C8616DC")
                    .IsUnique();

                entity.Property(e => e.CEmployeeCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cEmployeeCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CCandidateCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cCandidateCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CCity)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cCity")
                    .IsFixedLength(true);

                entity.Property(e => e.CCountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("cCountryCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CCurrentPosition)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cCurrentPosition")
                    .IsFixedLength(true);

                entity.Property(e => e.CDepartmentCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cDepartmentCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CDesignation)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cDesignation")
                    .IsFixedLength(true);

                entity.Property(e => e.CEmailId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cEmailId")
                    .IsFixedLength(true);

                entity.Property(e => e.CPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cPhone")
                    .IsFixedLength(true);

                entity.Property(e => e.CRegion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cRegion")
                    .IsFixedLength(true);

                entity.Property(e => e.CSex)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("cSex")
                    .IsFixedLength(true);

                entity.Property(e => e.CSocialSecurityNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cSocialSecurityNo")
                    .IsFixedLength(true);

                entity.Property(e => e.CState)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cState")
                    .IsFixedLength(true);

                entity.Property(e => e.CSupervisorCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cSupervisorCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CZip)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cZip")
                    .IsFixedLength(true);

                entity.Property(e => e.DBirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dBirthDate");

                entity.Property(e => e.DJoiningDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dJoiningDate");

                entity.Property(e => e.DResignationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dResignationDate");

                entity.Property(e => e.ImPhoto)
                    .HasColumnType("image")
                    .HasColumnName("imPhoto");

                entity.Property(e => e.VAddress)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("vAddress");

                entity.Property(e => e.VFirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vFirstName");

                entity.Property(e => e.VLastName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vLastName");

                entity.Property(e => e.VQualification)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vQualification");

                entity.HasOne(d => d.CCountryCodeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CCountryCode)
                    .HasConstraintName("FK__Employee__cCount__4CA06362");

                entity.HasOne(d => d.CDepartmentCodeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CDepartmentCode)
                    .HasConstraintName("FK__Employee__cDepar__4E88ABD4");
            });

            modelBuilder.Entity<EmployeeReferral>(entity =>
            {
                entity.HasKey(e => e.CEmployeeReferralNo)
                    .HasName("ert_pk");

                entity.Property(e => e.CEmployeeReferralNo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cEmployeeReferralNo")
                    .IsFixedLength(true);

                entity.Property(e => e.CCandidateCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cCandidateCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CEmployeeCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cEmployeeCode")
                    .IsFixedLength(true);

                entity.HasOne(d => d.CCandidateCodeNavigation)
                    .WithMany(p => p.EmployeeReferrals)
                    .HasForeignKey(d => d.CCandidateCode)
                    .HasConstraintName("FK__EmployeeR__cCand__628FA481");

                entity.HasOne(d => d.CEmployeeCodeNavigation)
                    .WithMany(p => p.EmployeeReferrals)
                    .HasForeignKey(d => d.CEmployeeCode)
                    .HasConstraintName("FK__EmployeeR__cEmpl__619B8048");
            });

            modelBuilder.Entity<EmployeeSkill>(entity =>
            {
                entity.HasKey(e => new { e.CEmployeeCode, e.CSkillCode })
                    .HasName("vest_pk");

                entity.ToTable("EmployeeSkill");

                entity.Property(e => e.CEmployeeCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cEmployeeCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CSkillCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cSkillCode")
                    .IsFixedLength(true);

                entity.HasOne(d => d.CEmployeeCodeNavigation)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.CEmployeeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeS__cEmpl__6754599E");

                entity.HasOne(d => d.CSkillCodeNavigation)
                    .WithMany(p => p.EmployeeSkills)
                    .HasForeignKey(d => d.CSkillCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeS__cSkil__68487DD7");
            });

            modelBuilder.Entity<ExternalCandidate>(entity =>
            {
                entity.HasKey(e => e.CCandidateCode)
                    .HasName("ectv_pk");

                entity.ToTable("ExternalCandidate");

                entity.Property(e => e.CCandidateCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cCandidateCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CAgencyCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cAgencyCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CCampusRecruitmentCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cCampusRecruitmentCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CCity)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cCity")
                    .IsFixedLength(true);

                entity.Property(e => e.CCollegeCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cCollegeCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CContractRecruiterCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cContractRecruiterCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CCountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("cCountryCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CEmployeeReferralNo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cEmployeeReferralNo")
                    .IsFixedLength(true);

                entity.Property(e => e.CExEmployeeCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cExEmployeeCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CInterviewer)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cInterviewer")
                    .IsFixedLength(true);

                entity.Property(e => e.CJobFairCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cJobFairCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CNewsAdNo)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cNewsAdNo")
                    .IsFixedLength(true);

                entity.Property(e => e.CPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cPhone")
                    .IsFixedLength(true);

                entity.Property(e => e.CPositionCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cPositionCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CRating)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("cRating")
                    .IsFixedLength(true);

                entity.Property(e => e.CSex)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("cSex")
                    .IsFixedLength(true);

                entity.Property(e => e.CState)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cState")
                    .IsFixedLength(true);

                entity.Property(e => e.CStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("cStatus")
                    .IsFixedLength(true);

                entity.Property(e => e.CZip)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cZip")
                    .IsFixedLength(true);

                entity.Property(e => e.DBirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dBirthDate");

                entity.Property(e => e.DDateOfApplication)
                    .HasColumnType("datetime")
                    .HasColumnName("dDateOfApplication");

                entity.Property(e => e.DInterviewDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dInterviewDate");

                entity.Property(e => e.DTestDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dTestDate");

                entity.Property(e => e.ImPhotograph)
                    .HasColumnType("image")
                    .HasColumnName("imPhotograph");

                entity.Property(e => e.MPrevAnnualSalary)
                    .HasColumnType("money")
                    .HasColumnName("mPrevAnnualSalary");

                entity.Property(e => e.SiPrevWorkExperience).HasColumnName("siPrevWorkExperience");

                entity.Property(e => e.SiTestScore).HasColumnName("siTestScore");

                entity.Property(e => e.VAddress)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("vAddress");

                entity.Property(e => e.VEmailId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vEmailId");

                entity.Property(e => e.VFirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vFirstName");

                entity.Property(e => e.VInterviewComments)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("vInterviewComments");

                entity.Property(e => e.VLastName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vLastName");

                entity.Property(e => e.VQualification)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vQualification");

                entity.HasOne(d => d.CAgencyCodeNavigation)
                    .WithMany(p => p.ExternalCandidates)
                    .HasForeignKey(d => d.CAgencyCode)
                    .HasConstraintName("FK__ExternalC__cAgen__5BE2A6F2");

                entity.HasOne(d => d.CCampusRecruitmentCodeNavigation)
                    .WithMany(p => p.ExternalCandidates)
                    .HasForeignKey(d => d.CCampusRecruitmentCode)
                    .HasConstraintName("FK__ExternalC__cCamp__5EBF139D");

                entity.HasOne(d => d.CContractRecruiterCodeNavigation)
                    .WithMany(p => p.ExternalCandidates)
                    .HasForeignKey(d => d.CContractRecruiterCode)
                    .HasConstraintName("FK__ExternalC__cCont__5CD6CB2B");

                entity.HasOne(d => d.CCountryCodeNavigation)
                    .WithMany(p => p.ExternalCandidates)
                    .HasForeignKey(d => d.CCountryCode)
                    .HasConstraintName("FK__ExternalC__cCoun__5812160E");

                entity.HasOne(d => d.CJobFairCodeNavigation)
                    .WithMany(p => p.ExternalCandidates)
                    .HasForeignKey(d => d.CJobFairCode)
                    .HasConstraintName("FK__ExternalC__cJobF__5DCAEF64");

                entity.HasOne(d => d.CNewsAdNoNavigation)
                    .WithMany(p => p.ExternalCandidates)
                    .HasForeignKey(d => d.CNewsAdNo)
                    .HasConstraintName("FK__ExternalC__cNews__5AEE82B9");

                entity.HasOne(d => d.CPositionCodeNavigation)
                    .WithMany(p => p.ExternalCandidates)
                    .HasForeignKey(d => d.CPositionCode)
                    .HasConstraintName("FK__ExternalC__cPosi__59FA5E80");
            });

            modelBuilder.Entity<InternalCandidate>(entity =>
            {
                entity.HasKey(e => new { e.CCandidateCode, e.CEmployeeCode, e.CInternalJobPostingCode })
                    .HasName("ict_pk");

                entity.ToTable("InternalCandidate");

                entity.Property(e => e.CCandidateCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cCandidateCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CEmployeeCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cEmployeeCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CInternalJobPostingCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cInternalJobPostingCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CInterviewer)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("cInterviewer")
                    .IsFixedLength(true);

                entity.Property(e => e.CPositionCodeAppliedFor)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cPositionCodeAppliedFor")
                    .IsFixedLength(true);

                entity.Property(e => e.CRating)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("cRating")
                    .IsFixedLength(true);

                entity.Property(e => e.CStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("cStatus")
                    .IsFixedLength(true);

                entity.Property(e => e.DDateOfApplication)
                    .HasColumnType("datetime")
                    .HasColumnName("dDateOfApplication");

                entity.Property(e => e.DInterviewDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dInterviewDate");

                entity.Property(e => e.DTestDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dTestDate");

                entity.Property(e => e.SiTestScore).HasColumnName("siTestScore");

                entity.Property(e => e.VInterviewComments)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("vInterviewComments");

                entity.HasOne(d => d.CInternalJobPostingCodeNavigation)
                    .WithMany(p => p.InternalCandidates)
                    .HasForeignKey(d => d.CInternalJobPostingCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__InternalC__cInte__46E78A0C");

                entity.HasOne(d => d.CPositionCodeAppliedForNavigation)
                    .WithMany(p => p.InternalCandidates)
                    .HasForeignKey(d => d.CPositionCodeAppliedFor)
                    .HasConstraintName("FK__InternalC__cPosi__47DBAE45");
            });

            modelBuilder.Entity<InternalJobPosting>(entity =>
            {
                entity.HasKey(e => e.CInternalJobPostingCode)
                    .HasName("ijp_pk");

                entity.ToTable("InternalJobPosting");

                entity.Property(e => e.CInternalJobPostingCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cInternalJobPostingCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CPositionCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cPositionCode")
                    .IsFixedLength(true);

                entity.Property(e => e.DDeadline)
                    .HasColumnType("datetime")
                    .HasColumnName("dDeadline");

                entity.Property(e => e.DNoticeReleaseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dNoticeReleaseDate");

                entity.Property(e => e.SiNoOfVacancies).HasColumnName("siNoOfVacancies");

                entity.Property(e => e.VRegion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vRegion");
            });

            modelBuilder.Entity<JobFair>(entity =>
            {
                entity.HasKey(e => e.CJobFairCode)
                    .HasName("jft_pk");

                entity.ToTable("JobFair");

                entity.Property(e => e.CJobFairCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cJobFairCode")
                    .IsFixedLength(true);

                entity.Property(e => e.DFairDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dFairDate");

                entity.Property(e => e.MFee)
                    .HasColumnType("money")
                    .HasColumnName("mFee");

                entity.Property(e => e.VJobFairCompany)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("vJobFairCompany");

                entity.Property(e => e.VLocation)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("vLocation");
            });

            modelBuilder.Entity<MonthlySalary>(entity =>
            {
                entity.HasKey(e => new { e.CEmployeeCode, e.DPayDate })
                    .HasName("mst_pk");

                entity.ToTable("MonthlySalary");

                entity.Property(e => e.CEmployeeCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cEmployeeCode")
                    .IsFixedLength(true);

                entity.Property(e => e.DPayDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dPayDate");

                entity.Property(e => e.MMonthlySalary)
                    .HasColumnType("money")
                    .HasColumnName("mMonthlySalary");

                entity.Property(e => e.MReferralBonus)
                    .HasColumnType("money")
                    .HasColumnName("mReferralBonus");

                entity.HasOne(d => d.CEmployeeCodeNavigation)
                    .WithMany(p => p.MonthlySalaries)
                    .HasForeignKey(d => d.CEmployeeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MonthlySa__cEmpl__5165187F");
            });

            modelBuilder.Entity<NewsAd>(entity =>
            {
                entity.HasKey(e => e.CNewsAdNo)
                    .HasName("nat_pk");

                entity.ToTable("NewsAd");

                entity.Property(e => e.CNewsAdNo)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cNewsAdNo")
                    .IsFixedLength(true);

                entity.Property(e => e.CNewspaperCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cNewspaperCode")
                    .IsFixedLength(true);

                entity.Property(e => e.DAdStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dAdStartDate");

                entity.Property(e => e.DDeadline)
                    .HasColumnType("datetime")
                    .HasColumnName("dDeadline");

                entity.HasOne(d => d.CNewspaperCodeNavigation)
                    .WithMany(p => p.NewsAds)
                    .HasForeignKey(d => d.CNewspaperCode)
                    .HasConstraintName("FK__NewsAd__cNewspap__30F848ED");
            });

            modelBuilder.Entity<Newspaper>(entity =>
            {
                entity.HasKey(e => e.CNewspaperCode)
                    .HasName("np_pk");

                entity.ToTable("Newspaper");

                entity.Property(e => e.CNewspaperCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cNewspaperCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CCity)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cCity")
                    .IsFixedLength(true);

                entity.Property(e => e.CCountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("cCountryCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CFax)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cFax")
                    .IsFixedLength(true);

                entity.Property(e => e.CNewspaperName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cNewspaperName")
                    .IsFixedLength(true);

                entity.Property(e => e.CPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cPhone")
                    .IsFixedLength(true);

                entity.Property(e => e.CState)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cState")
                    .IsFixedLength(true);

                entity.Property(e => e.CZip)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cZip")
                    .IsFixedLength(true);

                entity.Property(e => e.VContactPerson)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("vContactPerson");

                entity.Property(e => e.VHoaddress)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("vHOAddress");

                entity.Property(e => e.VRegion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vRegion");

                entity.Property(e => e.VTypeOfNewspaper)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vTypeOfNewspaper");

                entity.HasOne(d => d.CCountryCodeNavigation)
                    .WithMany(p => p.Newspapers)
                    .HasForeignKey(d => d.CCountryCode)
                    .HasConstraintName("FK__Newspaper__cCoun__2C3393D0");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => new { e.CSourceCode, e.CChequeNo, e.DDate })
                    .HasName("tp_pks");

                entity.ToTable("Payment");

                entity.Property(e => e.CSourceCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cSourceCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CChequeNo)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("cChequeNo")
                    .IsFixedLength(true);

                entity.Property(e => e.DDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dDate");

                entity.Property(e => e.MAmount)
                    .HasColumnType("money")
                    .HasColumnName("mAmount");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.CPositionCode)
                    .HasName("ptv_pk");

                entity.ToTable("Position");

                entity.Property(e => e.CPositionCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cPositionCode")
                    .IsFixedLength(true);

                entity.Property(e => e.IBudgetedStrength).HasColumnName("iBudgetedStrength");

                entity.Property(e => e.ICurrentStrength).HasColumnName("iCurrentStrength");

                entity.Property(e => e.SiYear).HasColumnName("siYear");

                entity.Property(e => e.VDescription)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("vDescription");
            });

            modelBuilder.Entity<PositionSkill>(entity =>
            {
                entity.HasKey(e => new { e.CPositionCode, e.CSkillCode })
                    .HasName("pstv_pk");

                entity.ToTable("PositionSkill");

                entity.Property(e => e.CPositionCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cPositionCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CSkillCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cSkillCode")
                    .IsFixedLength(true);

                entity.HasOne(d => d.CPositionCodeNavigation)
                    .WithMany(p => p.PositionSkills)
                    .HasForeignKey(d => d.CPositionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PositionS__cPosi__71D1E811");

                entity.HasOne(d => d.CSkillCodeNavigation)
                    .WithMany(p => p.PositionSkills)
                    .HasForeignKey(d => d.CSkillCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PositionS__cSkil__72C60C4A");
            });

            modelBuilder.Entity<RecruitmentAgency>(entity =>
            {
                entity.HasKey(e => e.CAgencyCode)
                    .HasName("rat_pk");

                entity.Property(e => e.CAgencyCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cAgencyCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CCity)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cCity")
                    .IsFixedLength(true);

                entity.Property(e => e.CFax)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cFax")
                    .IsFixedLength(true);

                entity.Property(e => e.CName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("cName")
                    .IsFixedLength(true);

                entity.Property(e => e.CPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cPhone")
                    .IsFixedLength(true);

                entity.Property(e => e.CState)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cState")
                    .IsFixedLength(true);

                entity.Property(e => e.CZip)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cZip")
                    .IsFixedLength(true);

                entity.Property(e => e.MTotalPaid)
                    .HasColumnType("money")
                    .HasColumnName("mTotalPaid");

                entity.Property(e => e.SiPercentageCharge).HasColumnName("siPercentageCharge");

                entity.Property(e => e.VAddress)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("vAddress");
            });

            modelBuilder.Entity<Recruitmentuser>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CPassword)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cPassword")
                    .IsFixedLength(true);

                entity.Property(e => e.CUserName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cUserName")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Requisition>(entity =>
            {
                entity.HasKey(e => new { e.CRequisitionCode, e.CPositionCode })
                    .HasName("RTP_PK");

                entity.ToTable("Requisition");

                entity.Property(e => e.CRequisitionCode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("cRequisitionCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CPositionCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cPositionCode")
                    .IsFixedLength(true);

                entity.Property(e => e.CDepartmentCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cDepartmentCode")
                    .IsFixedLength(true);

                entity.Property(e => e.DDateofRequisition)
                    .HasColumnType("datetime")
                    .HasColumnName("dDateofRequisition");

                entity.Property(e => e.DDeadline)
                    .HasColumnType("datetime")
                    .HasColumnName("dDeadline");

                entity.Property(e => e.SiNoOfVacancy).HasColumnName("siNoOfVacancy");

                entity.Property(e => e.VRegion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("vRegion");

                entity.HasOne(d => d.CPositionCodeNavigation)
                    .WithMany(p => p.Requisitions)
                    .HasForeignKey(d => d.CPositionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Requisiti__cPosi__6B24EA82");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasKey(e => e.CSkillCode)
                    .HasName("stv_pk");

                entity.ToTable("Skill");

                entity.Property(e => e.CSkillCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("cSkillCode")
                    .IsFixedLength(true);

                entity.Property(e => e.VSkill)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("vSkill");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
