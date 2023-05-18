using Application.Contracts.Presistence;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private ITaskRepository _taskRepositry;
        private ICheckListRepository _checkListRepository;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ITaskRepository TaskRepository
        {
            get
            {
                if (_taskRepositry == null)
                    _taskRepositry = new TaskRepository(_dbContext);
                return _taskRepositry;
            }
        }
        public ICheckListRepository CheckListRepository
        {
            get
            {
                if (_checkListRepository == null)
                    _checkListRepository = new CheckListRepository(_dbContext);
                return _checkListRepository;
            }
        }


        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
