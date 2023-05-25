using Domain;
namespace Application.Contracts.Presistence
{

    // ITaskRepository.cs
    public interface ITaskRepository : IRepository<ETask>
    {
        Task<IEnumerable<ETask>> GetTasksByUserIdAsync(string userId);
        Task<IEnumerable<ETask>> GetTasksByCompletionStatusAsync(bool completed);
        Task<ETask> GetTaskWithOwner(int Id);
        Task<IEnumerable<ETask>> GetALlTaskWithOwner();
        Task<ETask> GetTaskDetailed(int Id);
    }
}