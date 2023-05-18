using Application.Contracts.Presistence;
using Domain;
using Moq;

namespace Application.UnitTest.Mocks
{
    public static class MockCheckListRepository
    {

        public static Mock<ICheckListRepository> GetCheckListRepository()
        {


            var CheckLists = new List<CheckList>
            {
                new CheckList {
                    Id = 1,
                    Title = "checklist1",
                    Description ="this is a CheckList for task ..",
                    TaskId  = 1,
                    Completed = false
                },
                new CheckList {
                    Id = 2,
                    Title = "checklist2",
                    Description ="this is a CheckList for task ..",
                    TaskId  = 1,
                    Completed = false
                },

            };




            var mockRepo = new Mock<ICheckListRepository>();

            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(CheckLists);

            mockRepo.Setup(r => r.AddAsync(It.IsAny<CheckList>())).ReturnsAsync((CheckList checkList) =>
            {
                checkList.Id = CheckLists.Count() + 1;
                CheckLists.Add(checkList);
                return checkList;
            });

            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<CheckList>())).Callback((CheckList checkList) =>
            {
                var newCheckLists = CheckLists.Where((r) => r.Id != checkList.Id);
                CheckLists = newCheckLists.ToList();
                CheckLists.Add(checkList);
            });

            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<CheckList>())).Callback((CheckList checkList) =>
            {
                CheckLists.Remove(checkList);
            });

            mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {
                var checkList = CheckLists.FirstOrDefault((r) => r.Id == Id);
                return checkList != null;
            });


            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {
                return CheckLists.FirstOrDefault((r) => r.Id == Id);
            });

            mockRepo.Setup(r => r.GetCheckListsByTaskIdAsync(It.IsAny<int>())).ReturnsAsync((int taskId) =>
            {
                return  CheckLists.Where((r) => r.TaskId == taskId);
            });

            mockRepo.Setup(r => r.GetCheckListsByCompletionStatusAsync(It.IsAny<bool>())).ReturnsAsync((bool completed) =>
            {
                return CheckLists.Where((r) => r.Completed == completed);
            });

            return mockRepo;




        }

    }
}
