var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("redis");

var rabbitmq = builder.AddRabbitMQ("rabbitmq");

var seq = builder.AddSeq("seq");

var neo4j = builder.AddContainer(
        "neo4j",
        "neo4j")
    .WithEnvironment("NEO4J_AUTH", "neo4j/password")
    .WithHttpEndpoint(
        port: 7474,
        targetPort: 7474,
        name: "browser")
    .WithEndpoint(
        port: 7687,
        targetPort: 7687,
        name: "bolt");
var qdrant = builder.AddContainer(
        "qdrant",
        "qdrant/qdrant")
    .WithHttpEndpoint(
        port: 6333,
        targetPort: 6333,
        name: "http")
    .WithEndpoint(
        port: 6334,
        targetPort: 6334,
        name: "grpc");

builder.AddProject<Projects.Opzenix_Api>("api")
    .WithReference(redis)
    .WithReference(rabbitmq)
    .WithReference(seq);



builder.AddProject<Projects.Opzenix_Workers_Review>("review-worker")
    .WithReference(redis)
    .WithReference(rabbitmq)
    .WithReference(seq);

builder.AddProject<Projects.Opzenix_Workers_AI>("ai-worker")
    .WithReference(redis)
    .WithReference(rabbitmq)
    .WithReference(seq);

builder.AddProject<Projects.Opzenix_Workers_Repository>("repository-worker")
    .WithReference(redis)
    .WithReference(rabbitmq)
    .WithReference(seq);

builder.AddProject<Projects.Opzenix_Workers_Graph>("graph-worker")
    .WithReference(redis)
    .WithReference(rabbitmq)
    .WithReference(seq);

builder.Build().Run();