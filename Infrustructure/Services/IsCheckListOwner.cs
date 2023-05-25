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
            var userName = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userName == null) return Task.CompletedTask;

            var checkListId = int.Parse(_httpContextAccessor.HttpContext?.Request.RouteValues.SingleOrDefault(x => x.Key == "Id").Value!.ToString());

            if (checkListId == null) return Task.CompletedTask;

            var checkList = _dbContext.CheckLists.AsNoTracking()
                    .SingleOrDefaultAsync(clst => clst.Id == checkListId && clst.Task.Owner.UserName == userName)
                    .Result;

            if (checkList != null)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
