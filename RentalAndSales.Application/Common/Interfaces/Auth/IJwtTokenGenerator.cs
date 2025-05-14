namespace RentalAndSales.Application.Common.Interfaces.Auth;

public interface IJwtTokenGenerator
{
    string GenerateToken(Guid userId, string email, string fullName);
}