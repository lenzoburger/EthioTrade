using System;
using System.Security.Claims;
using System.Threading.Tasks;
using EthCoffee.api.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace  EthCoffee.api.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            var userId = int.Parse(resultContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var repo = resultContext.HttpContext.RequestServices.GetService<ITradingRepository>();
            var user =  await repo.GetUserDetails(userId);
            user.LastActiveDate = DateTime.Now;
            await repo.SaveAll();
        }
    }
}