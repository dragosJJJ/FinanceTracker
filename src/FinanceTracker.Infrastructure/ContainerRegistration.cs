using FinanceTracker.Domain.Interfaces;
using FinanceTracker.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceTracker.Infrastructure
{
    public static class ContainerRegistration
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICardRepository, CardRepository>();
        }
    }
}
