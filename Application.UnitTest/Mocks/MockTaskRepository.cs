using Application.Contracts.Presistence;
using Moq;

namespace Application.UnitTest.Mocks
{
    public static class MockTaskRepository
    {
        public static Mock<ITaskRepository> GetTaskRepository()
        {
            var Tasks = new List<Domain.Task>
            {
                 new Domain.Task
                {
                    Id = 1,
                    Owner  = 1,
                    Description = "description",
                    StartDate  = "20/2/2023",
                    EndDate  = "22/2/2023",
                    Completed = false
                },

                new Domain.Task
                {
                    Id = 2,
                    Owner  = 1,
                    Description = "description",
                    StartDate  = "20/2/2022",
                    EndDate  = "22/2/2022",
                    Completed = false
                 }
            };

            var mockRepo = new Mock<ITaskRepository>();

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(Tasks);

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Domain.Task>())).ReturnsAsync((Domain.Task task) =>
            {
                task.Id = Tasks.Count() + 1;
                Tasks.Add(task);
                return task;
            });

            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Domain.Task>())).Callback((Domain.Task task) =>
            {
                var newTasks = Tasks.Where((r) => r.Id != task.Id);
                Tasks = newTasks.ToList();
                Tasks.Add(task);
            });

            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<Domain.Task>())).Callback((Domain.Task task) =>
            {
                Tasks.Remove(task);
            });

            mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {
                var Task = Tasks.FirstOrDefault((r) => r.Id == Id);
                return Task != null;
            });


            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {
                return Tasks.FirstOrDefault((r) => r.Id == Id);
            });

            mockRepo.Setup(r => r.GetTasksByUserIdAsync(It.IsAny<int>())).ReturnsAsync((int userId) =>
            {
                return Tasks.Where((r) => r.Owner == userId);
            });


            mockRepo.Setup(r => r.GetTasksByCompletionStatusAsync(It.IsAny<bool>())).ReturnsAsync((bool completed) =>
            {
                return Tasks.Where((r) => r.Completed == completed);
            });

            return mockRepo;

        }
    }
}
