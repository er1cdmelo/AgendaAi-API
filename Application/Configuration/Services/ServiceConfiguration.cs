using Application.Configuration.Utils;
using Application.Data.Repositories;
using Application.Data;
using Microsoft.EntityFrameworkCore;
using Application.Configuration.Middlewares;
using AutoMapper;
using Application.Data.Mapper;
using Hangfire;
using Application.Presentation.Controllers;
using Application.Application.AppServices;
using Application.Application.Data.Mapper;
using Application.Infra.Data.Repositories;
using Application.Application.Mapper;

namespace Application.Configuration.Services
{
    public class ServiceConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddRouting();
            services.AddSwaggerGen();

            var connString = configuration.GetConnectionString("DefaultConnection");

            // Hangfire
            services.AddHangfire(x => x.UseSqlServerStorage(connString));
            services.AddDbContext<AgendaContext>(options =>
            {
                options.UseSqlServer(connString);
            });

            // AutoMapper
            var mapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ProfissionalProfile());
                mc.AddProfile(new UsuarioProfile());
                mc.AddProfile(new PreferenciaProfile());
                mc.AddProfile(new AgendamentoProfile());
                mc.AddProfile(new HorarioDisponivelProfile());
                mc.AddProfile(new UserTokenProfile());
                mc.AddProfile(new ClienteProfile());
                mc.AddProfile(new ServicoProfile());
            });
            services.AddSingleton(mapper.CreateMapper());

            // Repositories
            services.AddScoped<UsuarioRepository>();
            services.AddScoped<ProfissionalRepository>();
            services.AddScoped<PreferenciaRepository>();
            services.AddScoped<TokenRepository>();
            services.AddScoped<AgendamentoRepository>();
            services.AddScoped<ClienteRepository>();
            services.AddScoped<ServicoRepository>();

            // Utils
            services.AddScoped<SettingsManager>();
            services.AddScoped<TokenManager>();
            services.AddScoped<AuthorizationMiddleware>();

            // AppServices
            services.AddScoped<UsuarioAppServices>();
            services.AddScoped<ProfissionalAppServices>();
            services.AddScoped<PreferenciaAppServices>();
            services.AddScoped<PasswordAppServices>();
            services.AddScoped<AgendamentoAppServices>();
            services.AddScoped<TokenAppServices>();
            services.AddScoped<ClienteAppServices>();
            services.AddScoped<ServicoAppServices>();

            // Controllers
            services.AddScoped<ProfissionalController>();
            services.AddScoped<UsuarioController>();
            services.AddScoped<AgendamentoController>();
            services.AddScoped<ClienteController>();
            services.AddScoped<ServicoController>();
        }
    }
}
