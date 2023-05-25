using Application.Contracts.Presistence;
using Moq;

namespace Application.UnitTest.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockTaskRepo = MockTaskRepository.GetTaskRepository();
            var mockCheckListRepo = MockCheckListRepository.GetCheckListRepository();
          /*  var mockUserManager = MockUserManager.GetUserManager();*/


            mockUow.Setup(r => r.TaskRepository).Returns(mockTaskRepo.Object);
            mockUow.Setup(t => t.CheckListRepository).Returns(mockCheckListRepo.Object);
            /*mockUow.Setup(m => m.UserManager).Returns(mockUserManager.Object);*/
          
            mockUow.Setup(r => r.Save()).ReturnsAsync(1);

            return mockUow;

        }


    }
}
