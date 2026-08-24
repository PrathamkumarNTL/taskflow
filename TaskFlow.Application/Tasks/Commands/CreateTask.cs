using MediatR;
using TaskFlow.Application.Common.Interfaces;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Tasks.Commands;

public record CreateTaskCommand( Guid ProjectId, string Title) : IRequest<Guid>;

public class CreateTaskHandler(IAppDbContext db) : IRequestHandler<CreateTaskCommand, Guid>
{
    public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new TaskItem
        {
            ProjectId = request.ProjectId,
            Title = request.Title
        };

        db.Tasks.Add(task);
        await db.SaveChangesAsync(cancellationToken);

        return task.Id;
    }
}
