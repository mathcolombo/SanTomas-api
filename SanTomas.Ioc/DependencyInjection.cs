using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SanTomas.Application.Categories.Profiles;
using SanTomas.Application.Categories.Services;
using SanTomas.Application.Categories.Services.Interfaces;
using SanTomas.Application.Courses.Profiles;
using SanTomas.Application.Courses.Services;
using SanTomas.Application.Courses.Services.Interfaces;
using SanTomas.Application.CoursesUsers.Profiles;
using SanTomas.Application.CoursesUsers.Services;
using SanTomas.Application.CoursesUsers.Services.Interfaces;
using SanTomas.Application.MainCategories.Profiles;
using SanTomas.Application.MainCategories.Services;
using SanTomas.Application.MainCategories.Services.Interfaces;
using SanTomas.Application.Platforms.Profiles;
using SanTomas.Application.Platforms.Services;
using SanTomas.Application.Platforms.Services.Interfaces;
using SanTomas.Application.Users.Profiles;
using SanTomas.Application.Users.Services;
using SanTomas.Application.Users.Services.Interfaces;
using SanTomas.Domain.Categories.Repositories.Interfaces;
using SanTomas.Domain.Categories.Services;
using SanTomas.Domain.Categories.Services.Interfaces;
using SanTomas.Domain.Courses.Repositories.Interfaces;
using SanTomas.Domain.Courses.Services;
using SanTomas.Domain.Courses.Services.Interfaces;
using SanTomas.Domain.CoursesUsers.Repositories.Interfaces;
using SanTomas.Domain.CoursesUsers.Services;
using SanTomas.Domain.CoursesUsers.Services.Interfaces;
using SanTomas.Domain.MainCategories.Repositories.Interfaces;
using SanTomas.Domain.MainCategories.Services;
using SanTomas.Domain.MainCategories.Services.Interfaces;
using SanTomas.Domain.Platforms.Repositories.Interfaces;
using SanTomas.Domain.Platforms.Services;
using SanTomas.Domain.Platforms.Services.Interfaces;
using SanTomas.Domain.Users.Repositories.Interfaces;
using SanTomas.Domain.Users.Services;
using SanTomas.Domain.Users.Services.Interfaces;
using SanTomas.Domain.Utils.Repositories.Interfaces;
using SanTomas.Infra.Categories.Repositories;
using SanTomas.Infra.Courses.Repositories;
using SanTomas.Infra.CoursesUsers.Repositories;
using SanTomas.Infra.MainCategories.Repositories;
using SanTomas.Infra.Platforms.Repositories;
using SanTomas.Infra.Users.Repositories;
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
        services.AddAutoMapper(typeof(UsersProfile));
        services.AddAutoMapper(typeof(PlatformsProfile));
        services.AddAutoMapper(typeof(CoursesProfile));
        services.AddAutoMapper(typeof(CoursesUsersProfile));
        
        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IMainCategoriesApplicationService, MainCategoriesApplicationService>();
        services.AddScoped<ICategoriesApplicationService, CategoriesApplicationService>();
        services.AddScoped<IUsersApplicationService, UsersApplicationService>();
        services.AddScoped<IPlatformsApplicationService, PlatformsApplicationService>();
        services.AddScoped<ICoursesApplicationService, CoursesApplicationService>();
        services.AddScoped<ICoursesUsersApplicationService, CoursesUsersApplicationService>();
        
        return services;
    }

    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IMainCategoriesService, MainCategoriesService>();
        services.AddScoped<ICategoriesService, CategoriesService>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IPlatformsService, PlatformsService>();
        services.AddScoped<ICoursesService, CoursesService>();
        services.AddScoped<ICoursesUsersService, CoursesUsersService>();
        
        return services;
    }

    public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IMainCategoriesRepository, MainCategoriesRepository>();
        services.AddScoped<ICategoriesRepository, CategoriesRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IPlatformsRepository, PlatformsRepository>();
        services.AddScoped<ICoursesRepository, CoursesRepository>();
        services.AddScoped<ICoursesUsersRepository, CoursesUsersRepository>();
        
        return services;
    }
}