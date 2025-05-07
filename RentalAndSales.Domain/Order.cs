namespace RentalAndSales.Domain;

public class Order
{
    public Guid Id { get; set; }
    public Guid BuyerId { get; set; }
    public User Buyer { get; set; } = null!;

    public Guid CarId { get; set; }
    public Car Car { get; set; } = null!;

    public DateTime OrderDate { get; set; }
    public OrderType Type { get; set; }

}