using EmployeeSystem.Domain.Base;
using System.Collections.Generic;

namespace EmployeeSystem.Domain.Entities
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }
        public List<EmployeeSkill> EmployeeSkillList { get; set; }
    }
}