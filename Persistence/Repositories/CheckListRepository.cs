using Domain;
using Application.Contracts.Presistence;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{

    // ICheckListRepository.cs
    public class CheckListRepository : Repository<CheckList>,ICheckListRepository
    {
        private readonly AppDbContext _dbContext;

        public CheckListRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<IEnumerable<CheckList>> ICheckListRepository.GetCheckListsByTaskIdAsync(int taskId)
        {
            return await _dbContext.CheckLists.Where(clt => clt.Task.Id == taskId).ToListAsync();
        }

        async Task<IEnumerable<CheckList>> ICheckListRepository.GetCheckListsByCompletionStatusAsync(bool completed)
        {
            return await _dbContext.CheckLists.Where(clt => clt.Completed).ToListAsync();
        }
    }
}