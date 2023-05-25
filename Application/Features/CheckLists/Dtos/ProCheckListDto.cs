namespace Application.Features.CheckLists.Dtos
{
    public class ProCheckListDto : BaseDto
    {
        public string Title { get; set;  }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
