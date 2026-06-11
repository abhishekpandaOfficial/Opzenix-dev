using FluentValidation;
using Opzenix.Modules.Identity.Application.Commands.CreateOrganization;

namespace Opzenix.Modules.Identity.Application.Validators;

public sealed class CreateOrganizationValidator
    : AbstractValidator<CreateOrganizationCommand>
{
    public CreateOrganizationValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Slug)
            .NotEmpty()
            .MaximumLength(100);
    }
}