using FluentValidation;
using HemoConnect.Application.Commands.CreateDonation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemoConnect.Application.Validators
{
    public class CreateDonationValidator : AbstractValidator<CreateDonationCommand>
    {
        public CreateDonationValidator()
        {
            RuleFor(p => p.DonorId)
                .NotEmpty()
                    .WithMessage("O id do Doador é obrigatório");

            RuleFor(p => p.DonationDate)
                .NotEmpty()
                    .WithMessage("Data da doação é obrigatória")
                .LessThanOrEqualTo(DateTime.Today)
                    .WithMessage("A data não pode estar no futuro.");

            RuleFor(p => p.AmountML)
                .NotEmpty()
                    .WithMessage("Quantidade de ML é obrigatória")
                .GreaterThan(420)
                    .WithMessage("A quantiade mínima de coleta deve ser de 420 ML.")
                .LessThan(470)
                    .WithMessage("A quantiade máxima de coleta deve ser até 470 ML.");
        }
    }
}
