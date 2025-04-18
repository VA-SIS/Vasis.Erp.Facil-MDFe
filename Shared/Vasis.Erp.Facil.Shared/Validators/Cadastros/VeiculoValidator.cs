using FluentValidation;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Shared.Validators.Cadastros;

public class VeiculoValidator : AbstractValidator<Veiculo>
{
    public VeiculoValidator()
    {
        RuleFor(v => v.Placa)
            .NotEmpty().WithMessage("A placa é obrigatória.")
            .MaximumLength(10);

        RuleFor(v => v.Modelo).MaximumLength(100);
        RuleFor(v => v.Marca).MaximumLength(100);
        RuleFor(v => v.Tipo).MaximumLength(50);
        RuleFor(v => v.Cor).MaximumLength(50);
    }
}
