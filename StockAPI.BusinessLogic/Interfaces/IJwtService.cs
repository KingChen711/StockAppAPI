namespace StockAPI.BusinessLogic.Interfaces;

public interface IJwtService
{
    string CreateToken(int userId, int expirationInDays = 7);
    string? ValidateToken(string token);
}
