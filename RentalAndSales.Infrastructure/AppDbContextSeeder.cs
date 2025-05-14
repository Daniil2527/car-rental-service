using RentalAndSales.Domain;

namespace RentalAndSales.Infrastructure;

public static class AppDbContextSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        const string testEmail = "test@example.com";

        // Проверяем: если пользователь уже есть — выходим
        if (context.Users.Any(u => u.Email == testEmail))
            return;

        // Создаём пользователя
        var user = new User
        {
            Id = Guid.NewGuid(),
            FullName = "Test User",
            Email = testEmail,
            PhoneNumber = "+10000000000",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("123456")
        };

        // Создаём две машины
        var car1 = new Car
        {
            Id = Guid.NewGuid(),
            Brand = "Toyota",
            Model = "Corolla",
            Year = 2020,
            Price = 15000,
            Description = "Надёжный седан",
            IsForRent = false,
            Color = "White", 
            OwnerId = user.Id
        };

        var car2 = new Car
        {
            Id = Guid.NewGuid(),
            Brand = "Tesla",
            Model = "Model 3",
            Year = 2022,
            Price = 35000,
            Description = "Электромобиль",
            IsForRent = true,
            Color = "Red",
            OwnerId = user.Id
        };

        // Создаём заказ
        var order = new Order
        {
            Id = Guid.NewGuid(),
            BuyerId = user.Id,
            CarId = car2.Id,
            OrderDate = DateTime.UtcNow,
            Type = OrderType.Rent
        };

        // Добавляем всё в контекст
        await context.Users.AddAsync(user);
        await context.Cars.AddRangeAsync(car1, car2);
        await context.Orders.AddAsync(order);

        // Сохраняем в базу
        await context.SaveChangesAsync();
    }
}