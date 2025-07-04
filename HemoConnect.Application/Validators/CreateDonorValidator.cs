using FluentValidation;
using HemoConnect.Application.Commands.CreatDonor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Application.Validators
{
    public class CreateDonorValidator : AbstractValidator<CreateDonorCommand>
    {
        public CreateDonorValidator()
        {
            RuleFor(p => p.FullName)
                .NotEmpty()
                    .WithMessage("Nome é obrigatório")
                .MaximumLength(100)
                    .WithMessage("Nome não deve ultrapassar mais de 100 caracteres");

            RuleFor(p => p.Email)
                .EmailAddress()
                    .WithMessage("E-mail inválido");

            RuleFor(p => p.Weight)
                .NotEmpty()
                    .WithMessage("Peso é obrigatório")
                .Equal(0)
                    .WithMessage("Peso não pode ser zero");

            RuleFor(p => p.Gener)
                .NotEmpty()
                    .WithMessage("Gênero é obrigatório")
                .Must(g => g == "M" || g == "F")
                    .WithMessage("Gênero deve ser M ou F");

            RuleFor(p => p.BirthDate)
                .NotEmpty()
                    .WithMessage("Data de aniversário é obrigatória.");

            RuleFor(p => p.RHFactor)
                .NotEmpty()
                    .WithMessage("Fator RH é obrigatório");

            RuleFor(p => p.BloodType)
                .NotEmpty()
                    .WithMessage("Tipo do sangue é obrigatório");
        }
    }
}
