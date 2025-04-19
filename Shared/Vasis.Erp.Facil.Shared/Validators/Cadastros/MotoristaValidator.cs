using FluentValidation;
using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Shared.Domain.Validators;

public class MotoristaValidator : AbstractValidator<Motorista>
{
    public MotoristaValidator()
    {
        RuleFor(m => m.Nome)
            .NotEmpty().WithMessage("O nome do motorista é obrigatório.")
            .MaximumLength(200);

        //RuleFor(m => m.Cpf).MaximumLength(20);
        RuleFor(m => m.NumeroCnh).MaximumLength(20);
        RuleFor(m => m.CategoriaCnh).MaximumLength(5);
    }
}
