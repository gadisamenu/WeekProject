using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrustructure.Services
{
    public class IsTaskOwner : IAuthorizationRequirement
    {
    }

    public class IsTaskOwnerHandler : AuthorizationHandler<IsTaskOwner>
    {
        private readonly AppDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IsTaskOwnerHandler(AppDbContext dbContext,IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;

        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsTaskOwner requirement)
        {
            var userName= context.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userName == null) return Task.CompletedTask;

            var taskId = int.Parse(_httpContextAccessor.HttpContext?.Request.RouteValues
                                .SingleOrDefault(x => x.Key == "Id").Value!.ToString());
            
            if (taskId == null) return Task.CompletedTask;


            var task = _dbContext.Tasks.AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == taskId && x.Owner.UserName == userName)
                .Result;

            if (task !=null) 
                context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}