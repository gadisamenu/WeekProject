using Application.Contracts.Presistence;
using Microsoft.EntityFrameworkCore;
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

        async Task<IEnumerable<Domain.Task>> ITaskRepository.GetTasksByUserIdAsync(string userId)
        {
            return await _dbContext.Set<Domain.Task>().Where(tsk => tsk.Owner == userId).ToListAsync();
        }

        async Task<IEnumerable<Domain.Task>> ITaskRepository.GetTasksByCompletionStatusAsync(bool completed)
        {
            return await _dbContext.Set<Domain.Task>().Where(tsk => tsk.Completed).ToListAsync();
        }
    }
}