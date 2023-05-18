namespace Application.Features.Tasks.Dtos
{
    public class CreateTaskDto : ITaskDto
    {
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool Completed { get; set; }
    }
}
