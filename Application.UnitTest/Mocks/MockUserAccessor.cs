﻿using Application.Contracts;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;

namespace Application.UnitTest.Mocks
{
    public static  class MockUserAccessor
    {
        public static Mock<IUserAccessor> GetUserAccessor(){


            var httpContextMock = new Mock<HttpContext>();

            var userAccessor = new Mock<IUserAccessor>();
            userAccessor.Setup(a => a.GetUsername()).Returns(() => {
                httpContextMock.Object.User.FindFirstValue(ClaimTypes.NameIdentifier);
            });

            return userAccessor;
   
        }
     
    }
}