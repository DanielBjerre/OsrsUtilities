using OsrsUtilities.GroupService.Persistence;
using OsrsUtilities.MigrationService;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));

builder.AddSqlServerDbContext<GroupContext>("sqldata");

var host = builder.Build();
host.Run();
