using System;

namespace NetCoreSample.Models.API
{
    public class ApiCreatedTask
    {
        public Guid Id { get; set; }

        public ApiCreatedTask(Guid id)
        {
            Id = id;
        }
    }
}
