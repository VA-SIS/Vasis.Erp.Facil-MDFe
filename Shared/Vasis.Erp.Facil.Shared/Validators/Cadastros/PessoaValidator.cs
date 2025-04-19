
using FluentValidation;
using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Shared.Validators.Cadastros;

public class PessoaValidator : AbstractValidator<Pessoa>
{
    public PessoaValidator()
    {
        RuleFor(p => p.Nome)
            .NotEmpty().WithMessage("O nome é obrigatório.")
            .MaximumLength(200);

        RuleFor(p => p.TipoPessoa)
            .NotEmpty().WithMessage("Informe se é pessoa física ou jurídica.")
            .Must(t => t == "F" || t == "J").WithMessage("Tipo inválido. Use 'F' ou 'J'.");

        //RuleFor(p => p.CpfCnpj)
        //    .NotEmpty().WithMessage("CPF/CNPJ obrigatório.")
        //    .MaximumLength(20);
    }
}