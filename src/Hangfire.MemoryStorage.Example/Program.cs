using Hangfire;
using Hangfire.MemoryStorage.Example.Jobs;
using Hangfire.MemoryStorage;
using Hangfire.Console;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHangfire(hangfire =>
{
    hangfire
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseColouredConsoleLogProvider()
        .UseMemoryStorage()
        .UseConsole();

    var server = new BackgroundJobServer(new BackgroundJobServerOptions
    {
        ServerName = "hangfire-test",
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IMyRecurringJob, MyRecurringJob>();

var app = builder.Build();

app.UseHangfireDashboard();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

RecurringJob.AddOrUpdate<IMyRecurringJob>(JobIds.MyRecurringJob, job => job.Execute(), Cron.Minutely);

app.Run();
