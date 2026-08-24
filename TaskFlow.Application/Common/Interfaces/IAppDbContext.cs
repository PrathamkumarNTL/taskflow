using Microsoft.EntityFrameworkCore;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Common.Interfaces;

public interface IAppDbContext
{
    DbSet<Project> Projects { get; }

    DbSet<TaskItem> Tasks { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
