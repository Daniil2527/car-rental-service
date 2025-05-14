using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentalAndSales.Application.Common.Interfaces.Auth;
using RentalAndSales.Domain;
using RentalAndSales.Infrastructure.Auth;
using RentalAndSales.Infrastructure.Repositories;
using Microsoft.Extensions.Options;

namespace RentalAndSales.Infrastructure.DependencyInjection;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        // Подключение DbContext
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(config.GetConnectionString("DefaultConnection")));

        // Регистрация репозиториев
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        // Регистрация JwtSettings
        var jwtSettings = new JwtSettings();
        config.GetSection("JwtSettings").Bind(jwtSettings);
        services.AddSingleton(jwtSettings);

        // Регистрация генератора токена
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}