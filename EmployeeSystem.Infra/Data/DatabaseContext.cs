using EmployeeSystem.Infra.Entities;
using EmployeeSystem.Infra.Entities.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EmployeeSystem.Infra.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
