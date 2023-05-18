using AutoMapper;
using Application.Features.CheckLists.Dtos;
using Domain;
using Application.Features.Tasks.Dtos;

namespace BlogApp.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            #region checkList Mapping
            CreateMap<CheckList, CreateCheckListDto>().ReverseMap();
            CreateMap<CheckList, UpdateCheckListDto>().ReverseMap();
            CreateMap<CheckList, CheckListDto>().ReverseMap();
            #endregion checkList     

            #region checkList Mapping
            CreateMap<Domain.Task, CreateTaskDto>().ReverseMap();
            CreateMap<Domain.Task, UpdateTaskDto>().ReverseMap();
            CreateMap<Domain.Task, TaskDto>().ReverseMap();
            #endregion checkList 
        }
    }
}
