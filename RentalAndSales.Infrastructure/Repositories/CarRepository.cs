using Microsoft.EntityFrameworkCore;
using RentalAndSales.Domain;

namespace RentalAndSales.Infrastructure.Repositories;

public class CarRepository:ICarRepository
{
    private readonly AppDbContext _context;

    public CarRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Car?> GetByIdAsync(Guid id)
    {
        return await _context.Cars
            .Include(c => c.Owner)
            .Include(c => c.Orders)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(Car car)
    {
        await _context.Cars.AddAsync(car);
        await _context.SaveChangesAsync();
    }
}