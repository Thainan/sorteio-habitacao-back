using Microsoft.EntityFrameworkCore;
using SorteioHabitacaoThainan.Data.Context;
using SorteioHabitacaoThainan.Data.Repositories;
using SorteioHabitacaoThainan.Data.Repositories.Interfaces;
using SorteioHabitacaoThainan.Service.Services;
using SorteioHabitacaoThainan.Service.Services.Interfaces;

namespace SorteioHabitacaoThainan.Extensions
{
    public static class DataExtensions
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPessoaService, PessoaService>();
            return services;
        }
    }
}
