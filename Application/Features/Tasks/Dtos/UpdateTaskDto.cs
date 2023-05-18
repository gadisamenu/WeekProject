namespace Application.Features.Tasks.Dtos
{
    public class UpdateTaskDto : BaseDto, ITaskDto
    {
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }
}
