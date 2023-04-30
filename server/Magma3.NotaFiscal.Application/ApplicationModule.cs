using Magma3.NotaFiscal.Application.Commands.RegistrarNotaFiscal;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Magma3.NotaFiscal.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddMediatR(typeof(RegistrarNotaFiscalCommand));

            return services;
        }
    }
}