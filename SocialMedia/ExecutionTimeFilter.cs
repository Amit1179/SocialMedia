using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace SocialMedia
{
    public class ExecutionTimeFilter : IActionFilter
    {
        private Stopwatch _stopwatch;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            var timeTaken = _stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Time required: {timeTaken} ms");
        }
    }
}
