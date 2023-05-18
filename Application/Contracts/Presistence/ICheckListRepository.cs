using Domain;

namespace Application.Contracts.Presistence
{

    // ICheckListRepository.cs
    public interface ICheckListRepository : IRepository<CheckList>
    {
        Task<IEnumerable<CheckList>> GetCheckListsByTaskIdAsync(int taskId);
        Task<IEnumerable<CheckList>> GetCheckListsByCompletionStatusAsync(bool completed);
    }
}