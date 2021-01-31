using Microsoft.EntityFrameworkCore;
using NetCoreSample.Models.DTO.Enums;
using System;

namespace NetCoreSample.Models.DTO
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<JobTask> JobTask { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var initialJobTasks = new[]
            {
                new JobTask { Id = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow, Status = Status.Created },
                new JobTask { Id = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow, Status = Status.Finished },
                new JobTask { Id = Guid.NewGuid(), CreatedAt = DateTimeOffset.UtcNow, Status = Status.Running }
            };

            modelBuilder.Entity<JobTask>().HasData(initialJobTasks);
        }
    }
}
