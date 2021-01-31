using NetCoreSample.Interfaces;
using NetCoreSample.Models.DTO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreSample.Classes
{
    public class JobTaskRepository : IRepository<JobTask, Guid>
    {
        private readonly DatabaseContext _databaseContext;

        public JobTaskRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public JobTask GetById(Guid id)
        {
            return _databaseContext.JobTask.FirstOrDefault(jt => jt.Id == id);
        }

        public IQueryable<JobTask> Get()
        {
            return _databaseContext.JobTask;
        }

        public void Add(JobTask item)
        {
            item.CreatedAt = DateTimeOffset.UtcNow;

            _databaseContext.JobTask.Add(item);
        }

        public void Update(JobTask item)
        {
            item.UpdatedAt = DateTimeOffset.UtcNow;

            _databaseContext.JobTask.Update(item);
        }

        public void Delete(JobTask item)
        {
            _databaseContext.JobTask.Remove(item);
        }

        public Task SaveChangesAsync()
        {
            return _databaseContext.SaveChangesAsync();
        }
    }
}
