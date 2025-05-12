using AutoMapper;
using RentalAndSales.Application.Users.DTOs;
using RentalAndSales.Domain;

namespace RentalAndSales.Application.Users.Mappings;

public class UserMappingProfile: Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
    }
}