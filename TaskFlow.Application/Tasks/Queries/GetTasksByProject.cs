using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Common.Interfaces;

namespace TaskFlow.Application.Tasks.Queries
{
    public record TaskDto(Guid Id, string Title, string Status);

    public record GetTasksByProjectQuery(Guid ProjectId) : IRequest<List<TaskDto>>;

    public class GetTasksByProjectHandler(IAppDbContext db) : IRequestHandler<GetTasksByProjectQuery , List<TaskDto>>
    {
        public async Task<List<TaskDto>> Handle(GetTasksByProjectQuery request, CancellationToken cancellationToken)
        {
            return await db.Tasks.Where(t => t.ProjectId == request.ProjectId).Select(t => new TaskDto(t.Id, t.Title, t.Status.ToString())).ToListAsync(cancellationToken);
        }
    }
}
