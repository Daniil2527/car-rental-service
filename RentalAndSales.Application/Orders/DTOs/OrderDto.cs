using RentalAndSales.Domain;

namespace RentalAndSales.Application.Orders.DTOs;

public class OrderDto()
{
    public Guid Id { get; set; }
    public Guid BuyerId { get; set; }
    public Guid CarId { get; set; }
    public DateTime OrderDate { get; set; }
    public string BuyerName { get; set; } = string.Empty;
    public string CarName { get; set; } = string.Empty;
    public OrderType  Type { get; set; }
};