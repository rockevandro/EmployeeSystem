namespace EmployeeSystem.Domain.ApplicationModels
{
    public class EmployeeFilterModel
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public long GenderId { get; set; }
        public long SkillId { get; set; }
    }
}
