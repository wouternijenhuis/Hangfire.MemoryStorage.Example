using Microsoft.Extensions.Logging;
using Hangfire.MemoryStorage.Example.Jobs;

namespace Hangfire.MemoryStorage.Example.Tests;

public class MyRecurringJobTests
{
    [Fact]
    public async void MyRecurringJob()
    {
        var logger = new Mock<ILogger<MyRecurringJob>>();
        var job = new MyRecurringJob(logger.Object);

        var action = () => job.Execute();

        await action.Should().NotThrowAsync();
        logger.VerifyAll();
    }
}