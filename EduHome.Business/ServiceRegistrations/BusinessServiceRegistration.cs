﻿using EduHome.Business.Services.Abstractions;
using EduHome.Business.Services.Implementations;
using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EduHome.Business.ServiceRegistrations;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        AddServices(services);




        services.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.Password.RequiredLength = 4;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireUppercase = false;

        }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

        return services;
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<ILanguageService, LanguageService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICloudinaryService, CloudinaryService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<ICourseImageService, CourseImageService>();

    }
}
