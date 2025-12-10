using Microsoft.Extensions.DependencyInjection;
using OnionEAV.Application.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionEAV.Application.DependencyResolvers
{
    public static class DtoMapperResolver
    {

        public static void AddDtoMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DtoMappingProfile));
        }
    }
}
