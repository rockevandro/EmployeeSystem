using EmployeeSystem.Domain.Utils;
using System;

namespace EmployeeSystem.Domain.ApplicationModels
{
    public class EmployeeModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age => DateTimeUtils.GetAge(Birthdate);
        public string Gender { get; set; }
        public string[] SkillList { get; set; }
    }
}
