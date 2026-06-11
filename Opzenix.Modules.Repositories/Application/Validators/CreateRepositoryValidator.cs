using FluentValidation;
using Opzenix.Modules.Repositories.Application.Commands.CreateRepository;

namespace Opzenix.Modules.Repositories.Application.Validators;

public sealed class CreateRepositoryValidator
    : AbstractValidator<CreateRepositoryCommand>
{
    public CreateRepositoryValidator()
    {
        RuleFor(x => x.OrganizationId)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Url)
            .NotEmpty();

        RuleFor(x => x.Provider)
            .NotEmpty();
    }
}