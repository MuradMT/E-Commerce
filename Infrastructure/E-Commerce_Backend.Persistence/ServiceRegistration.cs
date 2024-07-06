﻿

namespace E_Commerce_Backend.Persistence;

public static class ServiceRegistration
{
     public static void AddPersistence(this IServiceCollection services,IConfiguration configuration){
               
               services.AddDbContext<AppDbContext>(options =>{
                    options.UseNpgsql(configuration.GetConnectionString("PgSqlConnection"));
               });
     }
}