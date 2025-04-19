using FluentValidation;
using Vasis.Erp.Facil.Shared.Domain.Entities;

namespace Vasis.Erp.Facil.Shared.Validators.Cadastros;

public class TransportadoraValidator : AbstractValidator<Transportadora>
{
    public TransportadoraValidator()
    {
   
        RuleFor(t => t.Cnpj)
            .MaximumLength(20);

        RuleFor(t => t.Uf)
            .MaximumLength(2);
    }
}
