using FluentValidation;
using Vasis.Erp.Facil.Shared.DTOs.Auth;

namespace Vasis.Erp.Facil.Shared.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequestDto>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Senha).NotEmpty().MinimumLength(6);
    }
}
