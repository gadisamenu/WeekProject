using Application.Features.CheckLists.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using System.Text;

namespace Infrustructure.Services
{
    public class IsCheckListTaskOwner:IAuthorizationRequirement
    {
    }

    public class IsCheckListTaskOwnerHandler : AuthorizationHandler<IsCheckListTaskOwner>
    {
        private readonly AppDbContext _dbContext;
        public readonly IHttpContextAccessor _httpContextAccessor;

        public IsCheckListTaskOwnerHandler(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }


        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, IsCheckListTaskOwner requirement)
        {
           /* var req = _httpContextAccessor.HttpContext.Request;
            using (StreamReader streamReader = new StreamReader(req.Body))
            {
                string requestBody = await streamReader.ReadToEndAsync();
                JSObject jsonBody = JSObject.Parse(requestBody);
            }*/
                /* var userName = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
                 if (userName == null)
                     return Task.CompletedTask;

                 req.EnableBuffering();

                 var checkList =req.ReadFromJsonAsync<CheckListDto>().Result;

                 var task = _dbContext.Tasks.AsNoTracking()
                    .SingleOrDefaultAsync(x => x.Id == checkList.TaskId && x.Owner.UserName == userName)
                    .Result;
                 if (task != null)
                     context.Succeed(requirement);
                 return Task.CompletedTask;*/

                /* HttpContext httpContext = httpContextAccessor.HttpContext;
                 HttpRequest request = httpContext.Request;

                 // Read the request body using BodyReader
                 using (var bodyReader = new StreamReader(request.Body))
                 {
                     // Assuming the request body is in JSON format
                     string requestBody = await bodyReader.ReadToEndAsync();

                     // Assuming the request body is in JSON format
                     JObject jsonBody = JObject.Parse(requestBody);

                     // Access specific fields from the JSON body
                     var field1 = jsonBody["Field1"]?.ToString();
                     var field2 = jsonBody["Field2"]?.ToString();
                     // ...
                 }*/
           /*     var userName = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userName == null)
                return Task.CompletedTask;

            var req = _httpContextAccessor.HttpContext.Request;
            req.EnableBuffering();

            // Read the request body as a string
            string requestBody;
            using (StreamReader reader = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
            {
                requestBody = await reader.ReadToEndAsync();
            }

            // Reset the request body position for further reading
            req.Body.Position = 0;

            // Deserialize the request body manually
            var checkList = JsonConvert.DeserializeObject<CheckListDto>(requestBody);

            var task = await _dbContext.Tasks.AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == checkList.TaskId && x.Owner.UserName == userName);

            if (task != null)
                context.Succeed(requirement);

            return Task.CompletedTask;*/

        }
    }
}


