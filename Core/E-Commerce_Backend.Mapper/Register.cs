using E_Commerce_Backend.Application.Interfaces.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce_Backend.Mapper;

public static class Register
{
     public static void AddCustomMapper(this IServiceCollection services){
        services.AddSingleton<IMapper,AutoMapper.Mapper>();
     }
}
