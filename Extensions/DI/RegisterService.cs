using System.Reflection;
using SystemManagementFactory.Domain.Entities;
using SystemManagementFactory.Repositories.BaseRepository;
using SystemManagementFactory.UOW;

namespace SystemManagementFactory.Extensions.DI;

public static class RegisterService
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        
        services.AddScoped<IGenericAddRepository<Farmer>, GenericAddRepository<Farmer>>();
        services.AddScoped<IGenericUpdateRepository<Farmer>, GenericUpdateRepository<Farmer>>();
        services.AddScoped<IGenericDeleteRepository<Farmer>, GenericDeleteRepository<Farmer>>();
        services.AddScoped<IGenericFindRepository<Farmer>, GenericFindRepository<Farmer>>();
        
        services.AddScoped<IGenericAddRepository<BusinessOwner>, GenericAddRepository<BusinessOwner>>();
        services.AddScoped<IGenericUpdateRepository<BusinessOwner>, GenericUpdateRepository<BusinessOwner>>();
        services.AddScoped<IGenericDeleteRepository<BusinessOwner>, GenericDeleteRepository<BusinessOwner>>();
        services.AddScoped<IGenericFindRepository<BusinessOwner>, GenericFindRepository<BusinessOwner>>();

        services.AddScoped<IGenericAddRepository<Crop>, GenericAddRepository<Crop>>();
        services.AddScoped<IGenericUpdateRepository<Crop>, GenericUpdateRepository<Crop>>();
        services.AddScoped<IGenericDeleteRepository<Crop>, GenericDeleteRepository<Crop>>();
        services.AddScoped<IGenericFindRepository<Crop>, GenericFindRepository<Crop>>();

        services.AddScoped<IGenericAddRepository<PurchaseRequest>, GenericAddRepository<PurchaseRequest>>();
        services.AddScoped<IGenericUpdateRepository<PurchaseRequest>, GenericUpdateRepository<PurchaseRequest>>();
        services.AddScoped<IGenericDeleteRepository<PurchaseRequest>, GenericDeleteRepository<PurchaseRequest>>();
        services.AddScoped<IGenericFindRepository<PurchaseRequest>, GenericFindRepository<PurchaseRequest>>();

        services.AddScoped<IGenericAddRepository<Transaction>, GenericAddRepository<Transaction>>();
        services.AddScoped<IGenericUpdateRepository<Transaction>, GenericUpdateRepository<Transaction>>();
        services.AddScoped<IGenericDeleteRepository<Transaction>, GenericDeleteRepository<Transaction>>();
        services.AddScoped<IGenericFindRepository<Transaction>, GenericFindRepository<Transaction>>();

        services.AddScoped<IGenericAddRepository<FarmerGarden>, GenericAddRepository<FarmerGarden>>();
        services.AddScoped<IGenericUpdateRepository<FarmerGarden>, GenericUpdateRepository<FarmerGarden>>();
        services.AddScoped<IGenericDeleteRepository<FarmerGarden>, GenericDeleteRepository<FarmerGarden>>();
        services.AddScoped<IGenericFindRepository<FarmerGarden>, GenericFindRepository<FarmerGarden>>();
        
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}