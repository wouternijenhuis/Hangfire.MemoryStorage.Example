using Hangfire.MemoryStorage.Example.Jobs;

using Microsoft.AspNetCore.Mvc;

namespace Hangfire.MemoryStorage.Example.Controllers;

[ApiController]
[Route("[controller]")]
public class JobsController(ILogger<JobsController> logger, IRecurringJobManager recurringJobManager) : ControllerBase
{
    [HttpGet("trigger")]
    public void Trigger()
    {
        logger.LogInformation("Trigger");

        recurringJobManager.Trigger(JobIds.MyRecurringJob);
    }

    [HttpDelete]
    public void Delete()
    {
        logger.LogInformation("Delete");

        recurringJobManager.RemoveIfExists(JobIds.MyRecurringJob);
    }
}
