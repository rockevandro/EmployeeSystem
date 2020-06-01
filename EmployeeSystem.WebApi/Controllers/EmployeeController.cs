using EmployeeSystem.Domain.ApplicationModels;
using EmployeeSystem.Domain.Entities;
using EmployeeSystem.Domain.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSystem.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ISkillRepository _skillRepository;
        private readonly IGenderRepository _genderRepository;

        public EmployeeController(IEmployeeRepository employeeRepository, ISkillRepository skillRepository, IGenderRepository genderRepository)
        {
            _employeeRepository = employeeRepository;
            _skillRepository = skillRepository;
            _genderRepository = genderRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(NewEmployeeModel newEmployeeModel)
        {
            var employee = new Employee(
                newEmployeeModel.FullName,
                newEmployeeModel.Birthdate,
                newEmployeeModel.Email,
                newEmployeeModel.GenderId,
                newEmployeeModel.SkillIdList);

            await _employeeRepository.Add(employee);
            return Ok();
        }

        [HttpPut("{EmployeeId}")]
        public async Task<IActionResult> Put(NewEmployeeModel newEmployeeModel, long employeeId)
        {
            var employee = new Employee(
                newEmployeeModel.FullName,
                newEmployeeModel.Birthdate,
                newEmployeeModel.Email,
                newEmployeeModel.GenderId,
                newEmployeeModel.SkillIdList);

            await _employeeRepository.Update(employee, employeeId);
            return Ok();
        }

        [HttpGet]
        public async Task<List<EmployeeModel>> Get([FromQuery]EmployeeFilterModel employeeFilter)
        {
            var employeeList = await _employeeRepository.GetAll(employeeFilter);
            return employeeList.Select(x => new EmployeeModel
            {
                Id = x.Id,
                Name = x.FullName,
                Email = x.Email,
                Birthdate = x.Birthdate,
                Gender = x.Gender.Name,
                SkillList = x.EmployeeSkillList.Select(y => y.Skill.Name).ToArray()
            }).ToList();
        }

        [HttpGet("{employeeId}")]
        public async Task<NewEmployeeModel> Get(long employeeId)
        {
            var employee = await _employeeRepository.GetById(employeeId);
            return  new NewEmployeeModel
            {
                FullName = employee.FullName,
                Email = employee.Email,
                Birthdate = employee.Birthdate,
                GenderId = employee.Gender.Id,
                SkillIdList = employee.EmployeeSkillList.Select(y => y.Skill.Id).ToArray()
            };
        }

        [HttpGet("skill")]
        public async Task<IEnumerable<SkillModel>> GetSkill()
        {
            var skillList = await _skillRepository.GetAll();
            return skillList.Select(x => new SkillModel
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        [HttpGet("gender")]
        public async Task<IEnumerable<Gender>> GetGender()
        {
            return await _genderRepository.GetAll();
        }
    }
}
