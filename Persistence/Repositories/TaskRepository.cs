using Application.Contracts.Presistence;
using Domain;
using Microsoft.EntityFrameworkCore;
namespace Persistence.Repositories
{

    // ITaskRepository.cs
    public class TaskRepository : Repository<ETask>,ITaskRepository
    {
        private readonly AppDbContext _dbContext;

        public TaskRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<IEnumerable<ETask>> ITaskRepository.GetTasksByUserIdAsync(string userId)
        {
            return await _dbContext.Set<ETask>().Where(tsk => tsk.Owner.Id == userId).ToListAsync();
        }

        async Task<IEnumerable<ETask>> ITaskRepository.GetTasksByCompletionStatusAsync(bool completed)
        {
            return await _dbContext.Set<ETask>().Where(tsk => tsk.Completed).ToListAsync();
        }
        async Task<ETask> ITaskRepository.GetTaskWithOwner(int Id)
        {
            return await _dbContext.Set<ETask>().Include(tsk => tsk.Owner).FirstOrDefaultAsync(tsk => tsk.Id == Id);
        }

        async Task<IEnumerable<ETask>> ITaskRepository.GetALlTaskWithOwner()
        {
            return await _dbContext.Set<ETask>().Include(tsk => tsk.Owner).ToListAsync();
        }

        async Task<ETask> ITaskRepository.GetTaskDetailed(int Id)
        {
            return await _dbContext.Set<ETask>().Include(tsk => tsk.Owner).Include(tsk=>tsk.CheckLists).FirstOrDefaultAsync(tsk => tsk.Id == Id);
        }
    }
}