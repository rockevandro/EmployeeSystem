using System;

namespace EmployeeSystem.WebMVC.Models
{
    public class EmployeeModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string[] SkillList { get; set; }
    }
}
