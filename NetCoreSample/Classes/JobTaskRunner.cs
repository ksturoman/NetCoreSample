using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetCoreSample.Interfaces;
using NetCoreSample.Models.DTO.Enums;
using System;
using System.Threading.Tasks;

namespace NetCoreSample.Classes
{
    public class JobTaskRunner : IJobTaskRunner
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<JobTaskRunner> _logger;

        public JobTaskRunner(IServiceProvider serviceProvider, ILogger<JobTaskRunner> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async void Run(Guid id)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();

                var jobTaskRepository = scope.ServiceProvider.GetService<JobTaskRepository>();

                var task = jobTaskRepository.GetById(id);

                if (task.Status == Status.Running)
                {
                    // Already running
                    return;
                }

                task.Status = Status.Running;

                jobTaskRepository.Update(task);

                await jobTaskRepository.SaveChangesAsync();

                await Task.Delay(TimeSpan.FromMinutes(2));

                task = jobTaskRepository.GetById(id);

                task.Status = Status.Finished;

                jobTaskRepository.Update(task);

                await jobTaskRepository.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, nameof(Run));
            }
        }
    }
}
