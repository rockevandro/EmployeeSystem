using EmployeeSystem.Domain.ApplicationModels;
using EmployeeSystem.Domain.Base;
using EmployeeSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.RepositoryInterfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<List<Employee>> GetAll(EmployeeFilterModel employeeFilter);
    }
}
