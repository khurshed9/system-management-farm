using Microsoft.EntityFrameworkCore;
using SystemManagementFactory.DB;

namespace GlobalExceptionHandler.DI;

public static class DbContextRegistration
{
    public static WebApplicationBuilder AddDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<BaseDbContext>(x =>
            x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddDbContext<AppCommandDbContext>(x =>
            x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        
        builder.Services.AddDbContext<AppQueryDbContext>(x =>
            x.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        
        return builder;
    }
}