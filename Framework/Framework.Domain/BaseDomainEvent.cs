using MediatR;

namespace Framework.Domain;

public class BaseDomainEvent : INotification
{
    public DateTime CreationDate { get; protected set; } = DateTime.UtcNow;

}