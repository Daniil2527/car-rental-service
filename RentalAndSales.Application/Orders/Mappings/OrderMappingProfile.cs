using AutoMapper;
using RentalAndSales.Application.Orders.DTOs;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Orders.Mappings;

public class OrderMappingProfile: Profile
{
    public OrderMappingProfile()
    {
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.BuyerName, opt => opt.MapFrom(scr => scr.Buyer.Email))
            .ForMember(dest => dest.CarName, opt => opt.MapFrom(scr=> scr.Car.Model))
            .ForMember(dest=> dest.Type, opt => opt.MapFrom(scr=>scr.Type.ToString()));
        
        CreateMap<OrderDto, Order>()
            .ForMember(dest => dest.Buyer, opt => opt.Ignore())
            .ForMember(dest => dest.Car, opt => opt.Ignore());
    }
}