using Application.Contracts.Presistence;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private ITaskRepository _taskRepositry;
        private ICheckListRepository _checkListRepository;
        private UserManager<User> _usermanager;
        private IServiceProvider _services;

        public UnitOfWork(AppDbContext dbContext,IServiceProvider services)
        {
            _dbContext = dbContext;
            _services = services;
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

        public UserManager<User> UserManager
        {
            get
            {
                if (_usermanager == null)
                    _usermanager = _services.GetService<UserManager<User>>();

                return _usermanager;
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
