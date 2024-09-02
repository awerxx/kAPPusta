using Projects;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Zoya_Api>("zoyaapi");
builder.AddProject<Zoya_Web_Admin>("zoyawebadmin");

builder.Build().Run();