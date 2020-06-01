using EmployeeSystem.Domain.Base;

namespace EmployeeSystem.Domain.Entities
{
    public class EmployeeSkill: BaseEntity
    {
        public Employee Employee { get; set; }
        public Skill Skill { get; set; }
        public long SkillId { get; set; }
    }
}
