using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspectOrientedWithDecorator.Filters;

public class DurationLoggingAttribute:Attribute,IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var sw = Stopwatch.StartNew();
        await next();
        sw.Stop();
        Console.WriteLine($"{context.ActionDescriptor.DisplayName} executed in {sw.ElapsedMilliseconds}ms");
    }
}