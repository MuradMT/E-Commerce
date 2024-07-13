

namespace E_Commerce_Backend.Persistence;

public static class ServiceRegistration
{
     public static void AddPersistence(this IServiceCollection services,IConfiguration configuration){
               
               services.AddDbContext<AppDbContext>(options =>{
                    options.UseNpgsql(configuration.GetConnectionString("PgSqlConnection"));
               });

               services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
               
               services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

               services.AddScoped<IUnitOfWork, UnitOfWork>();

               services.AddIdentityCore<User>(opt =>
                    {
                         opt.Password.RequireNonAlphanumeric = false;
                         opt.Password.RequiredLength = 2;
                         opt.Password.RequireLowercase = false;
                         opt.Password.RequireUppercase = false;
                         opt.Password.RequireDigit = false;
                         opt.SignIn.RequireConfirmedEmail = false;
                    })
                    .AddRoles<Role>()
                    .AddEntityFrameworkStores<AppDbContext>();
     }
}
