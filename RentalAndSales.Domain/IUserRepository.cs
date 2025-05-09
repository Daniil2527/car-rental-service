namespace RentalAndSales.Domain;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task AddAsync(User user);
}