using Domain.Interfaces;
using Domain.Interfaces.ChainResponsibility;
using Microsoft.Extensions.DependencyInjection;
using Services.ServicesChainResponsibility;

namespace ConsoleApp.DependencyInjection.ChainResponsibility
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddChainResponsibilityDI(this IServiceCollection services)
        {
            services.AddScoped<IIncomeTaxDiscountCalculator, IncomeTaxDiscountCalculator>();
            services.AddScoped<IIncomeTaxExemptRange, IncomeTaxExemptRange>();
            services.AddScoped<IIncomeTaxFirstRange, IncomeTaxFirstRange>();
            services.AddScoped<IIncomeTaxSecondRange, IncomeTaxSecondRange>();
            services.AddScoped<IIncomeTaxThirdRange, IncomeTaxThirdRange>();
            return services;
        }
    }
}
