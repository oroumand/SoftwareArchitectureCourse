using CourseStore.Host.Extensions;

var builder = WebApplication.CreateBuilder(args);

var app = builder.ConfigureService();

app.ConfigurePipeline();

app.Run();