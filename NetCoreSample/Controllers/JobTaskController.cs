using Microsoft.AspNetCore.Mvc;
using NetCoreSample.Classes;
using NetCoreSample.Interfaces;
using NetCoreSample.Models.API;
using NetCoreSample.Models.DTO;
using NetCoreSample.Models.DTO.Enums;
using System;
using System.Threading.Tasks;

namespace NetCoreSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobTaskController : ControllerBase
    {
        private readonly JobTaskRepository _jobTaskRepository;
        private readonly IJobTaskRunner _jobTaskRunner;

        public JobTaskController(JobTaskRepository jobTaskRepository, IJobTaskRunner jobTaskRunner)
        {
            _jobTaskRepository = jobTaskRepository;
            _jobTaskRunner = jobTaskRunner;
        }

        [HttpGet("{taskIdString}")]
        public IActionResult GetTask(string taskIdString)
        {
            if (!Guid.TryParse(taskIdString, out var taskId))
            {
                return BadRequest("You should send GUID value as parameter");
            }

            var task = _jobTaskRepository.GetById(taskId);

            if (task == null)
            {
                return NotFound($"Task with Id {taskId} not found");
            }

            return Ok(new ApiStatus(task));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask()
        {
            var newTask = new JobTask
            {
                Id = Guid.NewGuid(),
                Status = Status.Created
            };

            _jobTaskRepository.Add(newTask);

            await _jobTaskRepository.SaveChangesAsync();

            _jobTaskRunner.Run(newTask.Id);

            return Accepted(new ApiCreatedTask(newTask.Id));
        }
    }
}
