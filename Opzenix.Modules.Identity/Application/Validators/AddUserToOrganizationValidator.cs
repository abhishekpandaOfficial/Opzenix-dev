using FluentValidation;
using Opzenix.Modules.Identity.Application.Commands.AddUserToOrganization;

namespace Opzenix.Modules.Identity.Application.Validators;

public sealed class AddUserToOrganizationValidator
    : AbstractValidator<AddUserToOrganizationCommand>
{
    public AddUserToOrganizationValidator()
    {
        RuleFor(x => x.OrganizationId)
            .NotEmpty();

        RuleFor(x => x.UserId)
            .NotEmpty();
    }
}