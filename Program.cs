using System;
using LabExercise8.Data;
using LabExercise8.Models;
using LabExercise8.Repositories;
using System.Collections.Generic;

namespace LabExercise8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConfigurationHelper configuration = ConfigurationHelper.Instance();
            var dbConnection = configuration.GetProperty<string>("DbConnectionString");
            Console.WriteLine("Please enter employee code: ");
            string employeeCode = Console.ReadLine();

            using (RecruitmentContext context = new RecruitmentContext(dbConnection))
            {
                
                EmployeeRepository repository = EmployeeRepository.Instance(context);
                try
                {
                    Employee employee = repository.GetEmployeeByCode(employeeCode);
                    Console.WriteLine($"Employee Code: {employee.CEmployeeCode}, \nFirst Name: {employee.VFirstName}, \nLast Name: {employee.VLastName}, \nBirthday: {employee.DBirthDate}");
                    string position = repository.GetPosition(employee.CCurrentPosition);
                    Console.WriteLine($"Position: {position}");
                    List<AnnualSalary> annualSalaries = repository.GetAnnualSalary(employeeCode);
                    Console.WriteLine("\nAnnual Salary\n");
                    foreach (AnnualSalary annualSalary in annualSalaries)
                    {
                        Console.WriteLine($"Annual Salary: {annualSalary.MAnnualSalary}, Year: {annualSalary.SiYear}");
                    }

                    List<MonthlySalary> monthlySalaries = repository.GetMonthlySalary(employeeCode);
                    Console.WriteLine("\nMonthly Salary\n");
                    foreach (MonthlySalary monthlySalary in monthlySalaries)
                    {
                        Console.WriteLine($"Monthly Salary: {monthlySalary.MMonthlySalary}, Date: {monthlySalary.DPayDate}, Referral Bonus: {monthlySalary.MReferralBonus}");
                    }

                    List<string> skill = repository.GetEmployeeSkills(employeeCode);
                    Console.WriteLine("\nSkills\n");
                    foreach (string skillName in skill)
                    {
                        Console.WriteLine(skillName);
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
