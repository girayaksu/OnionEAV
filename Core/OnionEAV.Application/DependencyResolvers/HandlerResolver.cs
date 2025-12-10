using Microsoft.Extensions.DependencyInjection;
using OnionEAV.Application.CqrsAndMediatr.CQRS.Handlers.Read;

namespace OnionEAV.Application.DependencyResolvers
{

    public static class HandlerResolver
    {
        public static void AddHandlerService(this IServiceCollection services)
        {


            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(GetCategoryQueryHandler).Assembly));
        }
    }
}
