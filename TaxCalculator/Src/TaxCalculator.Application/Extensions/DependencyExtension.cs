using Microsoft.Extensions.DependencyInjection;
using TaxCalculator.Application.Services;
using TaxCalculator.Application.Services.Abstractions;

namespace TaxCalculator.Application.Extensions
{
    public static class DependencyExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICalculateTaxService, CalculateTaxService>();
        }
    }
}
