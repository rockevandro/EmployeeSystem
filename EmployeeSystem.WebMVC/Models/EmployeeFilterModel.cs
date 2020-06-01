using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;

namespace EmployeeSystem.WebMVC.Models
{
    public class EmployeeFilterModel
    {
        [DisplayName("Nome completo:")]
        public string FullName { get; set; }

        [DisplayName("Idade:")]
        public int Age { get; set; }

        [DisplayName("Sexo:")]
        public long GenderId { get; set; }

        public IEnumerable<SelectListItem> GenderList { get; set; }

        [DisplayName("Habilidades:")]
        public long SkillId { get; set; }

        public IEnumerable<SelectListItem> SkillList { get; set; }
    }
}
