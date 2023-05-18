using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CheckLists.Dtos
{
    public class CreateCheckListDto:ICheckListDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TaskId { get; set; }
        public bool Completed { get; set; }
    }
}
