using Microsoft.Extensions.DependencyInjection;
using OnionEAV.Application.ManagerInterfaces;
using OnionEAV.InnerInfrastructure.ManagerConcretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionEAV.InnerInfrastructure.DependencyResolvers
{

    public static class ManagerResolver
    {
        public static void AddManagerService(this IServiceCollection services)
        {
            services.AddScoped<IAppUserManager, AppUserManager>();
            services.AddScoped<IAppUserProfileManager, AppUserProfileManager>();
            services.AddScoped<ICategoryManager,CategoryManager>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IOrderDetailManager,OrderDetailManager>();
            services.AddScoped<IProductAttributeManager, ProductAttributeManager>();
            services.AddScoped<IProductAttributeValueManager, ProductAttributeValueManager>();

        }
    }
}
