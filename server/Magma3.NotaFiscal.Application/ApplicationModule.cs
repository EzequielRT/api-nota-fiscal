using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Magma3.NotaFiscal.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assemblyMediatrProject = AppDomain.CurrentDomain.Load("Magma3.NotaFiscal.Application");

            services.AddMediatR(assemblyMediatrProject);

            return services;
        }
    }
}