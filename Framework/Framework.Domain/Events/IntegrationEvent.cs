using System.Text.Json.Serialization;

namespace Framework.Domain.Events;

public class IntegrationEvent
{
    public IntegrationEvent()
    {
        EventId = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
        EventType = GetType().Name;
    }

    [JsonConstructor]
    public IntegrationEvent(Guid id, DateTime createDate)
    {
        EventId = id;
        CreationDate = createDate;
        EventType = GetType().Name;
    }

    [JsonInclude]
    public Guid EventId { get; init; }

    [JsonInclude]
    public DateTime CreationDate { get; init; }

    [JsonInclude]
    public string EventType { get; protected set; }
}
