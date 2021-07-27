using System;
using Cashless.Application.Contracts;
using Cashless.Application.Services;
using Cashless.Domain.Repositories;
using Cashless.Infrastructure.Database.EFContext;
using Cashless.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cashless.Infrastructure.DI
{
    public static class DepencyInjection
    {

        public static ServiceProvider Register(IServiceCollection services)
        {
            services.AddDbContext<CreditCardContext>(opt => opt.UseInMemoryDatabase(databaseName: "CustomerCreditCards"), ServiceLifetime.Singleton, ServiceLifetime.Singleton);

            services.AddSingleton<ICreditCardRepository, CreditCardRepository>();
            services.AddSingleton<ICreditCardService, CreditCardService>();

            return services.BuildServiceProvider();

        }

    }
}
