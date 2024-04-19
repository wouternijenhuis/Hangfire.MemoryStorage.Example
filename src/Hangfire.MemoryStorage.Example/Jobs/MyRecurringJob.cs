namespace Hangfire.MemoryStorage.Example.Jobs;

public interface IMyRecurringJob
{
    Task Execute();
}

internal class MyRecurringJob(ILogger<MyRecurringJob> logger) : IMyRecurringJob
{
    [AutomaticRetry(Attempts = 3)]
    public Task Execute()
    {
        logger.LogWarning("A warning presented itself.");
        return Task.CompletedTask;
    }
}