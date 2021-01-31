using NetCoreSample.Models.DTO;

namespace NetCoreSample.Models.API
{
    public class ApiStatus
    {
        public string Status { get; set; }
        public string Timestamp { get; set; }

        public ApiStatus(JobTask jobTask)
        {
            Status = jobTask.Status.ToString();
            Timestamp = jobTask.UpdatedAt?.ToString("O") ?? jobTask.CreatedAt?.ToString("O");
        }
    }
}
