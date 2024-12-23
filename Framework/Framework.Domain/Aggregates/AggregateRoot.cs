using Framework.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Framework.Domain.Aggregates;

public class AggregateRoot : BaseEntity
{
    private readonly List<BaseDomainEvent> _domainEvents = [];

    [NotMapped]
    public IEnumerable<BaseDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(BaseDomainEvent eventItem) => _domainEvents.Add(eventItem);

    public void RemoveDomainEvent(BaseDomainEvent eventItem) => _domainEvents.Remove(eventItem);

}