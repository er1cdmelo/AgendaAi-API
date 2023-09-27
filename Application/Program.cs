using Application.Configuration;
using Application.Configuration.Middlewares;
using Application.Configuration.Services;

var builder = WebApplication.CreateBuilder(args);

ServiceConfiguration.ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configura o Hangfire
HangfireConfiguration.ConfigureHangfire(builder.Configuration);

MiddlewareConfiguration.Configure(app, builder.Environment);

app.Run();