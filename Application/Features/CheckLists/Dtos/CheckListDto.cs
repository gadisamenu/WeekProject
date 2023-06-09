﻿namespace Application.Features.CheckLists.Dtos
{
    public class CheckListDto : BaseDto, ICheckListDto
    {
        public string Title { get; set;  }
        public string Description { get; set; }
        public int TaskId { get; set; }
        public bool Completed { get; set; }
    }
}
