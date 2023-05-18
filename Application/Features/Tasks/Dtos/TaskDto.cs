
using System.Buffers;

namespace Application.Features.Tasks.Dtos
{
    public class TaskDto : BaseDto, ITaskDto
    {
        public int Owner { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool Completed { get; set; }
    }
}
