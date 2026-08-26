using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Common.Interfaces;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) , IAppDbContext
    {
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<TaskItem> Tasks => Set<TaskItem>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Project>().HasIndex(p => p.TenantId);

            builder.Entity<TaskItem>().HasIndex(t => new {t.TenantId,t.ProjectId});

            base.OnModelCreating(builder);
        }
    }
}
