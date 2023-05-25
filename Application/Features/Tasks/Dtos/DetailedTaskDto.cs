using Application.Features.CheckLists.Dtos;
using Application.Profiles;
using Domain;

namespace Application.Features.Tasks.Dtos
{
    public class DetailedTaskDto : BaseDto
    {
        public UserProfile Owner { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Completed { get; set; }
        public ICollection<ProCheckListDto> CheckLists { get; set; }
    }
}
