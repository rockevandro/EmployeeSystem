using EmployeeSystem.WebMVC.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeSystem.WebMVC.Services
{
    public interface IEmployeeSystemApi
    {
        [Post("/employee")]
        Task NewEmployee([Body] NewEmployeeModel employeeModel);

        [Put("/employee/{employeeId}")]
        Task UpdateEmployee([Body] NewEmployeeModel employeeModel, long employeeId);

        [Get("/employee")]
        [QueryUriFormat(UriFormat.UriEscaped)]
        Task<List<EmployeeModel>> GetEmployee([Query]EmployeeFilterModel employeeFilter);

        [Get("/employee/{employeeId}")]
        Task<NewEmployeeModel> GetEmployeeById(long employeeId);

        [Get("/employee/skill")]
        Task<List<SkillModel>> GetSkill();

        [Get("/employee/gender")]
        Task<List<GenderModel>> GetGender();
    }
}
