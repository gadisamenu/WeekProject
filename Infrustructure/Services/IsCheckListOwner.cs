using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Security.Claims;

namespace Infrustructure.Services
{
    public class IsCheckListOwner:IAuthorizationRequirement
    {
    }

    public class IsCheckListOwnerHandler : AuthorizationHandler<IsCheckListOwner>
    {
        private readonly AppDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IsCheckListOwnerHandler(AppDbContext dbContext,IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsCheckListOwner requirement)
        {
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Task.CompletedTask;

            var checkListId = (int)_httpContextAccessor.HttpContext?.Request.RouteValues.SingleOrDefault(x => x.Key == "Id").Value;

            if (checkListId == null) return Task.CompletedTask;

            var checkList = _dbContext.Tasks.AsNoTracking()
                    .SingleOrDefaultAsync(x => x.Id == checkListId)
                    .Result;

            if (checkList == null) return Task.CompletedTask;
            if (checkList.Owner == userId) context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
