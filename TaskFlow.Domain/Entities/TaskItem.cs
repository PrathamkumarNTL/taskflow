using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities;

public enum TaskStatus
{
    Todo,
    InProgress,
    Done
}

public class TaskItem : BaseEntity
{
    public Guid TenantId { get; set; }
    public Guid ProjectId { get; set; }
    public string Title { get; set; } = default!;
    public TaskStatus Status { get; set; } = TaskStatus.Todo;
    public Guid? AssigneeId { get; set; }
}