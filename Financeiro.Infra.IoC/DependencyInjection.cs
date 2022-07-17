using Financeiro.Application.Interfaces;
using Financeiro.Application.Mappings;
using Financeiro.Application.Services;
using Financeiro.Domain.Interfaces;
using Financeiro.Infra.Data.Context;
using Financeiro.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Financeiro.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = "Server=172.17.0.2;User Id=root;Password=R0omArmY;Database=CleanArch;Initial Catalog=Financeiro";
            var serverVersion = ServerVersion.AutoDetect(connectionString);

            services.AddDbContext<AppDbContext>(options => options
                .UseMySql(connectionString, serverVersion));

            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();

            services.AddScoped<IBankService, BankService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

            return services;
        }
    }
}