namespace Application.Features.Tasks.Dtos
{
    public class UpdateTaskDto : BaseDto, ITaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
