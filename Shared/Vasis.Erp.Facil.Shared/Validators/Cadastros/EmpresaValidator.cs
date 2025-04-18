using FluentValidation;
using Vasis.Erp.Facil.Shared.Entities.Cadastros;

namespace Vasis.Erp.Facil.Shared.Validators.Cadastros;

public class EmpresaValidator : AbstractValidator<Empresa>
{
    public EmpresaValidator()
    {
        RuleFor(x => x.RazaoSocial).NotEmpty().WithMessage("Razão Social é obrigatória.");
        RuleFor(x => x.NomeFantasia).NotEmpty().WithMessage("Nome Fantasia é obrigatório.");
        RuleFor(x => x.Cnpj).NotEmpty().WithMessage("CNPJ é obrigatório.")
            .Length(14, 18).WithMessage("CNPJ deve conter entre 14 e 18 caracteres.");
    }
}