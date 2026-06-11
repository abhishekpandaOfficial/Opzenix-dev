namespace Opzenix.BuildingBlocks.Application;

public sealed record Error(
    string Code,
    string Description);