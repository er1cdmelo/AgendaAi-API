using Application.Configuration.Middlewares;
using Application.Configuration.Utils;
using Application.Data;
using Application.Data.Repositories;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AgendaContext>(options =>
{
    options.UseSqlServer(connString);
});

builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<ProfissionalRepository>();
builder.Services.AddScoped<TokenRepository>();
builder.Services.AddScoped<SettingsManager>();
builder.Services.AddScoped<TokenManager>();
builder.Services.AddScoped<AuthorizationMiddleware>();
builder.Services.AddHangfire(configuration => configuration
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage("Data Source=ERIC-PC\\SQLEXPRESS;Initial Catalog=AgendaAi1;Integrated Security=True;TrustServerCertificate=true;"));
builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<AuthorizationMiddleware>();
app.UseHangfireDashboard();
RecurringJob.AddOrUpdate("Primeiro Serviço", () => Debug.WriteLine("Hello World!"), "35 19 * * *", new RecurringJobOptions()
{
    TimeZone = TimeZoneInfo.Local
});

app.MapControllers();

app.Run();
