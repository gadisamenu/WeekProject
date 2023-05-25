using Domain;
using Microsoft.AspNetCore.Identity;

namespace Application.Contracts.Presistence
{
    public interface IUnitOfWork:IDisposable
    {
        ITaskRepository TaskRepository { get; }
        ICheckListRepository CheckListRepository { get; }
        UserManager<User> UserManager { get; }
        Task<int> Save();
    }
}
