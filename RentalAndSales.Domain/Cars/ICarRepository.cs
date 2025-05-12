namespace RentalAndSales.Domain;

public interface ICarRepository
{
    Task AddAsync(Car car, CancellationToken cancellationToken);
    Task UpdateAsync(Car car, CancellationToken cancellationToken);
    Task DeleteAsync(Car car, CancellationToken cancellationToken);
    Task<Car?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Car>> GetAllAsync(CancellationToken cancellationToken);
    
    
}