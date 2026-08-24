namespace TaskFlow.Domain.Common;

public abstract class BaseEntity
{
    private readonly List<IDomainEvent> _events = new();

    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAtUtc { get; set; }
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _events.AsReadOnly();
    public void Raise(IDomainEvent domainEvent)
    {
        _events.Add(domainEvent);
    }
    public void ClearEvents()
    {
        _events.Clear();
    }
}