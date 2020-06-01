using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeSystem.Domain.Base;
using EmployeeSystem.Domain.Utils;

namespace EmployeeSystem.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public Employee()
        {
        }

        public Employee(string fullName, DateTime birthdate, string email, long genderId, long[] skillIdList)
        {
            FullName = fullName;
            Birthdate = birthdate;
            Email = email;
            GenderId = genderId;
            EmployeeSkillList = skillIdList.Select(x => new EmployeeSkill
            {
                SkillId = x,
            }).ToList();
        }

        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public long GenderId { get; set; }
        public List<EmployeeSkill> EmployeeSkillList { get; set; }
    }
}
