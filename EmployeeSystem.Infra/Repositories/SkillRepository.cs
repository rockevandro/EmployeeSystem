using EmployeeSystem.Domain.Entities;
using EmployeeSystem.Domain.RepositoryInterfaces;
using EmployeeSystem.Infra.Data;

namespace EmployeeSystem.Infra.Repositories
{
    public class SkillRepository : BaseRepository<Skill>, ISkillRepository
    {
        public SkillRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
