using EmployeeSystem.Domain.ApplicationModels;
using EmployeeSystem.Domain.Utils;
using FluentValidation;
using System;

namespace EmployeeSystem.WebApi.Validations
{
    public class EmployeeModelValidation : AbstractValidator<NewEmployeeModel>
    {
        public EmployeeModelValidation()
        {
            RuleFor(x => x.FullName).Must(BeTwoAtLeast).WithMessage("Nome completo deve conter nome e sobrenome");
            RuleFor(x => x.Birthdate).NotEmpty().WithMessage("Data de nascimento deve ser informada").Must(ComeOfAge).WithMessage("Idade deve ser maior que 18 anos");
            RuleFor(x => x.Email).EmailAddress().When(x => x.Email?.Length > 0).WithMessage("Email deve estar em um formato válido");
            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Sexo deve ser informado");
            RuleFor(x => x.SkillIdList).NotEmpty().WithMessage("Alguma habilidade deve ser selecionada");
            RuleForEach(x => x.SkillIdList).NotEmpty().WithMessage("Alguma habilidade deve ser selecionada");
        }

        private bool BeTwoAtLeast(string fullName)
        {
            return fullName?.Trim().Split(' ').Length > 1;
        }

        private bool ComeOfAge(DateTime birthdate)
        {
            if (birthdate > DateTime.Now)
                return false;

            return DateTimeUtils.GetAge(birthdate) >= 18;
        }
    }
}
