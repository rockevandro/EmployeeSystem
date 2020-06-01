using EmployeeSystem.Domain.Entities;
using EmployeeSystem.Domain.RepositoryInterfaces;
using EmployeeSystem.Infra.Data;

namespace EmployeeSystem.Infra.Repositories
{
    public class GenderRepository : BaseRepository<Gender>, IGenderRepository
    {
        public GenderRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
