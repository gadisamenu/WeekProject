using AutoMapper;
using Application.Features.CheckLists.Dtos;
using Domain;
using Application.Features.Tasks.Dtos;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region checkList Mapping
            CreateMap<CheckList, CreateCheckListDto>().ReverseMap();
            CreateMap<CheckList, UpdateCheckListDto>().ReverseMap();
            CreateMap<CheckList, CheckListDto>().ReverseMap();
            CreateMap<CheckList, ProCheckListDto>();
            #endregion checkList     

            #region task Mapping
            CreateMap<ETask, CreateTaskDto>().ReverseMap();
            CreateMap<ETask, UpdateTaskDto>().ReverseMap();

            CreateMap<ETask, TaskDto>()
                .ForMember(tsk => tsk.OwnerId, o => o.MapFrom(o => o.Owner.Id));

            CreateMap<ETask, DetailedTaskDto>();
            CreateMap<User, UserProfile>();
            CreateMap<TaskDto, ETask>();

            #endregion task 
        }
    }
}
