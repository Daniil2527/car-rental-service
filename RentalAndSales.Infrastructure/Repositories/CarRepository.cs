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

    public async Task<Car?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Cars
            .Include(c => c.Owner)
            .Include(c => c.Orders)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task<List<Car>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Cars
            .Include(c => c.Owner)
            .Include(c => c.Orders)
            .ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(Car car, CancellationToken cancellationToken)
    {
        _context.Cars.Update(car);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task AddAsync(Car car, CancellationToken cancellationToken)
    {
        await _context.Cars.AddAsync(car, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Car car, CancellationToken cancellationToken)
    {
        _context.Cars.Remove(car);
        await _context.SaveChangesAsync(cancellationToken);
    }
}