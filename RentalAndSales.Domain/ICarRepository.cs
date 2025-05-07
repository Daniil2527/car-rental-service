namespace RentalAndSales.Domain;

public interface ICarRepository
{
    Task<Car?> GetByIdAsync(Guid id);
    Task AddAsync(Car car);
}