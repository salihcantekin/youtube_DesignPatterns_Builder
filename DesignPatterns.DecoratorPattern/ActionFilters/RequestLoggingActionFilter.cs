using Microsoft.AspNetCore.Mvc.Filters;

namespace DesignPatterns.DecoratorPattern.ActionFilters;

public class RequestLoggingActionFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // do something
        await next();
        // do something
    }
}
