using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeSystem.WebMVC.Models
{
    public class NewEmployeeModel
    {
        [HiddenInput]
        public long EmployeeId { get; set; }

        [DisplayName("Nome completo")]
        public string FullName { get; set; }

        [DisplayName("Data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }

        [DisplayName("Sexo")]
        public long GenderId { get; set; }

        [DisplayName("Habilidades")]
        public long[] SkillIdList { get; set; }

        public string[] ErrorMessage { get; set; }
    }
}
