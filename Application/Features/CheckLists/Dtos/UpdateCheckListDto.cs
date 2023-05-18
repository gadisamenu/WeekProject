namespace Application.Features.CheckLists.Dtos
{
    public class UpdateCheckListDto : BaseDto,ICheckListDto
    {
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
