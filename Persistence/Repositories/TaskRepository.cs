using Application.Contracts.Presistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Persistence.Repositories
{

    // ITaskRepository.cs
    public class TaskRepository : Repository<Domain.Task>,ITaskRepository
    {
        private readonly AppDbContext _dbContext;

        public TaskRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<IEnumerable<Domain.Task>> ITaskRepository.GetTasksByUserIdAsync(int userId)
        {
            return await _dbContext.Set<Domain.Task>().Where(tsk => tsk.Owner == userId).ToListAsync();
        }

        async Task<IEnumerable<Domain.Task>> ITaskRepository.GetTasksByCompletionStatusAsync(bool completed)
        {
            return await _dbContext.Set<Domain.Task>().Where(tsk => tsk.Completed).ToListAsync();
        }
    }
}