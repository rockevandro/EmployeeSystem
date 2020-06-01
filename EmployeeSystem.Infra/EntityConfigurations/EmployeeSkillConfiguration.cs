using EmployeeSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeSystem.Infra.Entities.EntityConfigurations
{
    class EmployeeSkillConfiguration : IEntityTypeConfiguration<EmployeeSkill>
    {
        public void Configure(EntityTypeBuilder<EmployeeSkill> builder)
        {
        }
    }
}
