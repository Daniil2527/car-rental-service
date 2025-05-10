using AutoMapper;
using RentalAndSales.Application.Cars.DTOs;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Cars.Mappings;

public class CarMappingProfile: Profile
{
    public CarMappingProfile()
    {
        CreateMap<Car, CarDto>();
        CreateMap<CarDto, Car>();
    }
}