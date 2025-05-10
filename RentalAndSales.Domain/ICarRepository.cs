namespace RentalAndSales.Domain;

public interface ICarRepository
{
    Task<Car?> GetByIdAsync(Guid id);
    Task<List<Car>> GetAllAsync();
    Task UpdateAsync(Car car);
    Task AddAsync(Car car);
    Task DeleteAsync(Guid id);
    
    
}