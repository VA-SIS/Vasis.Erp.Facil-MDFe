// Projeto: Vasis.Erp.Facil.Application
// Arquivo: Validators/EmpresaDtoValidator.cs
using FluentValidation;
using Vasis.Erp.Facil.Application.Dtos.Cadastros;

namespace Vasis.Erp.Facil.Application.Validators
{
    public class EmpresaDtoValidator : AbstractValidator<EmpresaDto>
    {
        public EmpresaDtoValidator()
        {
            RuleFor(e => e.Cnpj)
                .NotEmpty().WithMessage("O CNPJ é obrigatório.")
                .Matches("^[0-9]{14}$").WithMessage("O CNPJ deve conter 14 dígitos.");

            RuleFor(e => e.RazaoSocial)
                .NotEmpty().WithMessage("A razão social é obrigatória.")
                .MaximumLength(100);

            RuleFor(e => e.NomeFantasia)
                .MaximumLength(100).WithMessage("O nome fantasia deve ter no máximo 100 caracteres.");
        }
    }
}