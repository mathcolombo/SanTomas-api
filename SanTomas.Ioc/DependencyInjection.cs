using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SanTomas.Application.Categories.Profiles;
using SanTomas.Application.Categories.Services;
using SanTomas.Application.Categories.Services.Interfaces;
using SanTomas.Application.MainCategories.Profiles;
using SanTomas.Application.MainCategories.Services;
using SanTomas.Application.MainCategories.Services.Interfaces;
using SanTomas.Domain.Categories.Repositories.Interfaces;
using SanTomas.Domain.Categories.Services;
using SanTomas.Domain.Categories.Services.Interfaces;
using SanTomas.Domain.MainCategories.Repositories.Interfaces;
using SanTomas.Domain.MainCategories.Services;
using SanTomas.Domain.MainCategories.Services.Interfaces;
using SanTomas.Domain.Utils.Repositories.Interfaces;
using SanTomas.Infra.Categories.Repositories;
using SanTomas.Infra.MainCategories.Repositories;
using SanTomas.Infra.Utils.Repositories;

namespace SanTomas.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddAbstractions(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblies(typeof(Repository<>).Assembly)
            .AddClasses(classes => classes.AssignableTo(typeof(Repository<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return services;
    }
    
    public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MainCategoriesProfile));
        services.AddAutoMapper(typeof(CategoriesProfile));
        
        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IMainCategoriesApplicationService, MainCategoriesApplicationService>();
        services.AddScoped<ICategoriesApplicationService, CategoriesApplicationService>();
        
        return services;
    }

    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IMainCategoriesService, MainCategoriesService>();
        services.AddScoped<ICategoriesService, CategoriesService>();
        
        return services;
    }

    public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IMainCategoriesRepository, MainCategoriesRepository>();
        services.AddScoped<ICategoriesRepository, CategoriesRepository>();
        
        return services;
    }
}