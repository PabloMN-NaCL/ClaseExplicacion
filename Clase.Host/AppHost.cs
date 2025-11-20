var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Clase_Api_Identity>("clase-api-identity");

builder.Build().Run();
