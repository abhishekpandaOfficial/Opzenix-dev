namespace Opzenix.BuildingBlocks.Domain;
using MediatR;

public interface IDomainEvent :INotification
{
    DateTime OccurredOnUtc { get; }
}