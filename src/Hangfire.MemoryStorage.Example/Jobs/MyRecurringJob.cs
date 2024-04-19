using Hangfire.Console;
using Hangfire.Server;

namespace Hangfire.MemoryStorage.Example.Jobs;

public interface IMyRecurringJob
{
    Task Execute(PerformContext? performContext);
}

internal class MyRecurringJob(ILogger<MyRecurringJob> logger) : IMyRecurringJob
{
    [AutomaticRetry(Attempts = 3)]
    public Task Execute(PerformContext? performContext)
    {
        logger.LogWarning("A warning presented itself.");
        performContext?.WriteLine("I've executed the job.");
        return Task.CompletedTask;
    }
}