using FluentValidation;
using Opzenix.Modules.Identity.Application.Commands.CreateUser;

namespace Opzenix.Modules.Identity.Application.Validators;

public sealed class CreateUserValidator
    : AbstractValidator<CreateUserCommand>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.DisplayName)
            .NotEmpty()
            .MaximumLength(200);
    }
}