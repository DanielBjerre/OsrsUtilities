var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var sql = builder.AddSqlServer("sql", port: 14329)
                 .WithEndpoint(name: "sqlEndpoint", targetPort: 14330)
                 .AddDatabase("groups");

var migrationService = builder.AddProject<Projects.OsrsUtilities_MigrationService>("osrsutilities-migrationservice");

var apiService = builder.AddProject<Projects.OsrsUtilities_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.OsrsUtilities_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.AddProject<Projects.OsrsUtilities_GroupService>("osrsutilities-groupservice")
    .WithReference(sql)
    .WithReference(migrationService)
    .WaitForCompletion(migrationService);

builder.AddProject<Projects.OsrsUtilities_SnapshotService>("osrsutilities-snapshotservice");

builder.AddProject<Projects.OsrsUtilities_Snapshot_MigrationService>("osrsutilities-snapshot-migrationservice");

builder.Build().Run();
