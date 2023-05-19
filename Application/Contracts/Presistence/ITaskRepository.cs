using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Application.Contracts.Presistence
{

    // ITaskRepository.cs
    public interface ITaskRepository : IRepository<Domain.Task>
    {
        Task<IEnumerable<Domain.Task>> GetTasksByUserIdAsync(string userId);
        Task<IEnumerable<Domain.Task>> GetTasksByCompletionStatusAsync(bool completed);
    }
}