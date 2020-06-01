using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmployeeSystem.WebMVC.Models;
using Refit;
using EmployeeSystem.WebMVC.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace EmployeeSystem.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeSystemApi _employeeSystemApi;
        public HomeController(IConfiguration configuration)
        {
            _employeeSystemApi = RestService.For<IEmployeeSystemApi>(configuration["EmployeeSystem:URL"], new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                }),
            });
        }

        public async Task<IActionResult> Index(EmployeeViewModel employeeViewModel)
        {
            try
            {
                var genderList = new List<SelectListItem>()
                {
                    new SelectListItem("Selecione", "0")
                };

                var skillList = new List<SelectListItem>()
                {
                    new SelectListItem("Nenhum", "0")
                };

                genderList.AddRange((await _employeeSystemApi.GetGender()).Select(x => new SelectListItem(x.Name, x.Id.ToString())));
                skillList.AddRange((await _employeeSystemApi.GetSkill()).Select(x => new SelectListItem(x.Name, x.Id.ToString())));

                if (employeeViewModel.EmployeeList == null)
                {
                    var employeeList = await _employeeSystemApi.GetEmployee(null);
                    employeeViewModel = new EmployeeViewModel
                    {
                        EmployeeFilter = new EmployeeFilterModel
                        {
                            GenderList = genderList,
                            SkillList = skillList
                        },
                        EmployeeList = employeeList
                    };
                }
                else
                {
                    employeeViewModel.EmployeeFilter.GenderList = genderList;
                    employeeViewModel.EmployeeFilter.SkillList = skillList;
                }

                return View("Index", employeeViewModel);
            }
            catch (ApiException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create(long employeeId)
        {
            try
            {
                var genderList = new List<SelectListItem>()
                {
                    new SelectListItem("Selecione", "0")
                };

                genderList.AddRange((await _employeeSystemApi.GetGender()).Select(x => new SelectListItem(x.Name, x.Id.ToString())));

                ViewBag.GenderList = genderList;
                ViewBag.SkillList = (await _employeeSystemApi.GetSkill()).Select(x => new SelectListItem(x.Name, x.Id.ToString()));

                if (employeeId == 0)
                    return View();

                var newEmployeeModel = await _employeeSystemApi.GetEmployeeById(employeeId);
                newEmployeeModel.EmployeeId = employeeId;

                return View(newEmployeeModel);
            }
            catch (ApiException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewEmployeeModel model)
        {
            try
            {
                if (model.EmployeeId == 0)
                    await _employeeSystemApi.NewEmployee(model);
                else
                    await _employeeSystemApi.UpdateEmployee(model, model.EmployeeId);

                return RedirectToAction("Index");
            }
            catch (ValidationApiException ex)
            {
                model.ErrorMessage = ex.Content.Errors.Values.SelectMany(x => x).ToArray();
                var genderList = new List<SelectListItem>()
                {
                    new SelectListItem("Selecione", "0")
                };

                genderList.AddRange((await _employeeSystemApi.GetGender()).Select(x => new SelectListItem(x.Name, x.Id.ToString())));

                ViewBag.GenderList = genderList;
                ViewBag.SkillList = (await _employeeSystemApi.GetSkill()).Select(x => new SelectListItem(x.Name, x.Id.ToString()));

                return View("Create", model);
            }
            catch(Exception ex)
            {
                model.ErrorMessage = new[] { ex.Message };
                return View("Create", model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Filter(EmployeeFilterModel employeeFilter)
        {
            try
            {
                var employeeList = await _employeeSystemApi.GetEmployee(employeeFilter);
                return await Index(new EmployeeViewModel { EmployeeList = employeeList, EmployeeFilter = employeeFilter });
            }
            catch (ApiException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
