using Microsoft.Extensions.DependencyInjection;
using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Persistence.RepositoryConcretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionEAV.Persistence.DependencyResolvers
{
 
    public static class RepositoryResolver
    {
        public static void AddRepositoryService(this IServiceCollection services)
        {



            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IAppUserProfileRepository,AppUserProfileRepository>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IOrderRepository,OrderRepository>();
            services.AddScoped<IOrderDetailRepository,OrderDetailRepository>();
            services.AddScoped<IProductAttributeRepository,ProductAttributeRepository>();
            services.AddScoped<IProductAttributeValueRepository,ProductAttributeValueRepository>();
        
          
        }
    }
}
