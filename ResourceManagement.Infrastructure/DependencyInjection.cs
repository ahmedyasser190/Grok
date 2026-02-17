using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResourceManagement.Application.Interfaces;
using ResourceManagement.Domain.Abstractions;
using ResourceManagement.Domain.Abstractions.IRepositories;
using ResourceManagement.Infrastructure.Identity;
using ResourceManagement.Infrastructure.Persistence;
using ResourceManagement.Infrastructure.Persistence.Repositories;
using ResourceManagement.Infrastructure.Services;

namespace ResourceManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IResourceRepository, ResourceRepository>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<INotificationService, NotificationService>();

        services
    .AddIdentityCore<User>()
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

        return services;
    }
}
