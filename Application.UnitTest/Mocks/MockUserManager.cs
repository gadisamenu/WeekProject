using Domain;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Globalization;
using System.Threading.Tasks;

namespace Application.UnitTest.Mocks
{
    public class MockUserManager
    {
        public static  Mock<UserManager<User>> GetUserManager()
        {
            var Users = new List<User> {
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "myUserName1",
                    Email = "email1@gmail.com",
                    Password = "password",
                    FullName  = "this is may name "
                },
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "myUserName2",
                    Email = "email2@gmail.com",
                    Password = "password",
                    FullName  = "this is may name "
                }
            };
                
           
            var userManagerMock = new Mock<UserManager<User>>();
            var user = new User();
            userManagerMock.Setup(u => u.CreateAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            userManagerMock.Setup(u => u.Users).Returns(Users.AsQueryable());

            return userManagerMock;

        }
    }
}
