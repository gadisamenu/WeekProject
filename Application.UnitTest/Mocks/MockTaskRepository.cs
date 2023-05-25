using Application.Contracts.Presistence;
using Domain;
using Moq;
using System.Globalization;

namespace Application.UnitTest.Mocks
{
    public static class MockTaskRepository
    {
        public static Mock<ITaskRepository> GetTaskRepository()
        {
            var Tasks = new List<ETask>
            {
                 new ETask
                {
                    Id = 1,
                    Owner  = new User(),
                    Title = "Title",
                    Description = "description",
                    StartDate  = DateTime.ParseExact("20/02/2023 00:00","dd/MM/yyyy hh:mm",CultureInfo.InvariantCulture),
                    EndDate  = DateTime.ParseExact("22/02/2023 00:00","dd/MM/yyyy hh:mm",CultureInfo.InvariantCulture),
                    Completed = false
                },

                new ETask
                {
                    Id = 2,
                    Title = "Title",
                    Owner  = new User(),
                    Description = "description",
                    StartDate  = DateTime.ParseExact("20/02/2023 00:00","dd/MM/yyyy hh:mm",CultureInfo.InvariantCulture),
                    EndDate  = DateTime.ParseExact("22/02/2023 00:00","dd/MM/yyyy hh:mm",CultureInfo.InvariantCulture),
                    Completed = false
                 }
            };

            var mockRepo = new Mock<ITaskRepository>();

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(Tasks);

            mockRepo.Setup(r => r.AddAsync(It.IsAny<ETask>())).ReturnsAsync((ETask task) =>
            {
                task.Id = Tasks.Count() + 1;
                Tasks.Add(task);
                return task;
            });

            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<ETask>())).Callback((ETask task) =>
            {
                var newTasks = Tasks.Where((r) => r.Id != task.Id);
                Tasks = newTasks.ToList();
                Tasks.Add(task);
            });

            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<ETask>())).Callback((ETask task) =>
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

            mockRepo.Setup(r => r.GetTasksByUserIdAsync(It.IsAny<string>())).ReturnsAsync((string userId) =>
            {
                return Tasks.Where((r) => r.Owner.Id == userId);
            });


            mockRepo.Setup(r => r.GetTasksByCompletionStatusAsync(It.IsAny<bool>())).ReturnsAsync((bool completed) =>
            {
                return Tasks.Where((r) => r.Completed == completed);
            });

            return mockRepo;

        }
    }
}
