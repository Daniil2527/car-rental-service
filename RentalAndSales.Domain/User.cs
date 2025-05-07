namespace RentalAndSales.Domain;

public class User
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Car> Cars { get; set; } = new List<Car>();
}