// Projeto: Vasis.Erp.Facil.Application
// Arquivo: Validators/EmpresaValidator.cs
using FluentValidation;
using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Application.Validators
{
    public class EmpresaValidator : AbstractValidator<Empresa>
    {
        public EmpresaValidator()
        {
            RuleFor(e => e.NomeFantasia)
                .NotEmpty().WithMessage("O nome da empresa é obrigatório.")
                .MaximumLength(100);

            RuleFor(e => e.Cnpj)
                .NotEmpty().WithMessage("O CNPJ é obrigatório.")
                .Matches("^[0-9]{14}$").WithMessage("O CNPJ deve conter 14 dígitos numéricos.");
        }
    }
}
