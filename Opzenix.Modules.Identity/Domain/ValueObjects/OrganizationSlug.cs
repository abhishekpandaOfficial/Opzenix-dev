using Opzenix.BuildingBlocks.Domain;

namespace Opzenix.Modules.Identity.Domain.ValueObjects;

public sealed class OrganizationSlug : ValueObject
{
    public string Value { get; }

    public OrganizationSlug(string value)
    {
        Value = value.Trim().ToLowerInvariant();
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString()
    {
        return Value;
    }
}