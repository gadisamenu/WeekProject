namespace Application.Features.Tasks.Dtos
{
    public class TaskDto : BaseDto, ITaskDto
    {
        public string OwnerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Completed { get; set; }
    }
}
