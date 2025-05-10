using Microsoft.EntityFrameworkCore;
using RentalAndSales.Domain;

namespace RentalAndSales.Infrastructure.Repositories;

public class UserRepository: IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        
            return await _context.Users
                .Include(u => u.Cars)
                .Include(u => u.Orders)
                .FirstOrDefaultAsync(u => u.Id == id);
        
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }
}