using MMCourseStore.Host.RestEndpoint.Extensions;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureService();

app.ConfigurePipeline();

app.Run();
