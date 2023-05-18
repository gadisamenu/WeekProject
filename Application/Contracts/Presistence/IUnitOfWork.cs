namespace Application.Contracts.Presistence
{
    public interface IUnitOfWork:IDisposable
    {
        ITaskRepository TaskRepository { get; }
        ICheckListRepository CheckListRepository { get; }
        Task<int> Save();
    }
}
