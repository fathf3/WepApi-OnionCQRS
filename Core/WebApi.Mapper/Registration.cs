
using Microsoft.Extensions.DependencyInjection;

using WebApi.Application.Interfaces.AutoMapper;


    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, Mapper.AutoMapper.Mapper>(); 
        }
    }

