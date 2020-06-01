using EmployeeSystem.Domain.ApplicationModels;
using EmployeeSystem.Domain.Entities;
using EmployeeSystem.Domain.RepositoryInterfaces;
using EmployeeSystem.Infra.Data;
using EmployeeSystem.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSystem.Infra
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DatabaseContext context) : base(context)
        {
        }

        public override async Task<List<Employee>> GetAll()
        {
            return await _dbSet
                .Include(x => x.Gender)
                .Include(x => x.EmployeeSkillList)
                    .ThenInclude(x => x.Skill).ToListAsync();
        }

        public override async Task Update(Employee entity, long id)
        {
            entity.Id = id;
            var employeeSkillListToUpdate = entity.EmployeeSkillList;

            var employeeSkillListFromDB = _dbSet
                .Include(x => x.EmployeeSkillList)
                .Where(x => x.Id == id)
                .SelectMany(x => x.EmployeeSkillList).ToList();

            entity.EmployeeSkillList = entity.EmployeeSkillList
                .Where(x => !employeeSkillListFromDB.Any(y => y.SkillId == x.SkillId)).ToList();

            var employeeSkillListToRemove = employeeSkillListFromDB.Where(x => !employeeSkillListToUpdate.Any(y => y.SkillId == x.SkillId));

            _context.Set<EmployeeSkill>().RemoveRange(employeeSkillListToRemove);
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public override async Task<Employee> GetById(long id)
        {
            var employee = await _dbSet
                .Include(x => x.Gender)
                .Include(x => x.EmployeeSkillList)
                    .ThenInclude(x => x.Skill)
                    .SingleAsync(x => x.Id == id);

            return employee;
        }

        public async Task<List<Employee>> GetAll(EmployeeFilterModel employeeFilter)
        {
            IQueryable<Employee> employeeList = _dbSet.AsQueryable<Employee>();

            if (!string.IsNullOrWhiteSpace(employeeFilter.FullName))
                employeeList = employeeList.Where(x => x.FullName == employeeFilter.FullName);

            if (employeeFilter.Age > 0)
            {
                var agebirthDateFrom = DateTime.Today.AddYears(-(employeeFilter.Age + 1));
                var agebirthDateTo = DateTime.Today.AddYears(-(employeeFilter.Age));
                employeeList = employeeList.Where(x => x.Birthdate > agebirthDateFrom && x.Birthdate <= agebirthDateTo);
            }

            if (employeeFilter.GenderId > 0)
                employeeList = employeeList.Where(x => x.GenderId == employeeFilter.GenderId);

            if (employeeFilter.SkillId > 0)
                employeeList = employeeList.Where(x => x.EmployeeSkillList.Any(y => employeeFilter.SkillId == y.SkillId));

            return await employeeList
                .Include(x => x.Gender)
                .Include(x => x.EmployeeSkillList)
                .ThenInclude(x => x.Skill).ToListAsync();
        }
    }
}
