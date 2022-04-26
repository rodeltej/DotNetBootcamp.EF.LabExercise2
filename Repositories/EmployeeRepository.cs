using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabExercise8.Data;
using LabExercise8.Models;

namespace LabExercise8.Repositories
{
    public class EmployeeRepository
    {
        private static RecruitmentContext Context { get; set; }
        private static EmployeeRepository INSTANCE { get; set; }

        private EmployeeRepository(RecruitmentContext context)
        {
            Context = context;
        }
        public static EmployeeRepository Instance(RecruitmentContext context)
        {
            if(INSTANCE == null)
            {
                INSTANCE = new EmployeeRepository(context);
            }
            return INSTANCE;
        }

        public Employee GetEmployeeByCode(string employeeCode)
        {
            var employee = Context.Employees.Where(p => p.CEmployeeCode.Equals(employeeCode)).FirstOrDefault();
            if(employee == null)
            {
                throw new Exception($"Employee with code {employeeCode} doesn't exist.");
              
            }
            return employee;
        }

        public string GetPosition(string employeePositionCode)
        {
            var positionCode = Context.Positions.Where(p => p.CPositionCode.Equals(employeePositionCode)).FirstOrDefault();
            return positionCode.VDescription;
        }
        
        public List<AnnualSalary> GetAnnualSalary(string employeeCode)
        {
            var annualSalaries = Context.AnnualSalaries.Where(p => p.CEmployeeCode.Equals(employeeCode)).ToList();
            return annualSalaries;
        }

        public List<MonthlySalary> GetMonthlySalary(string employeeCode)
        {
            var monthlySalaries = Context.MonthlySalaries.Where(p => p.CEmployeeCode.Equals(employeeCode)).ToList();
            return monthlySalaries;
        }

        public List<string> GetEmployeeSkills(string employeeCode)
        {
            var skills = Context.EmployeeSkills
                .Join(Context.Skills, 
                es => es.CSkillCode, 
                s => s.CSkillCode, 
                (es, s) => new { EmployeeCode = es.CEmployeeCode, SkillCode = es.CSkillCode, Skill = s.VSkill })
                .Where(e => e.EmployeeCode
                .Equals(employeeCode))
                .ToList();
            List<string> skillList = new List<string>();
            foreach(var skill in skills)
            {
                skillList.Add(skill.Skill);
            }
            return skillList;

        }

        
    }
}
