using System;

namespace EmployeeSystem.Domain.ApplicationModels
{
    public class NewEmployeeModel
    {
        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public long GenderId { get; set; }
        public long[] SkillIdList { get; set; }
    }
}
