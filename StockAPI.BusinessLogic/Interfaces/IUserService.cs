using StockAPI.Models;

namespace StockAPI.BusinessLogic.Interfaces;

public interface IUserService
{
    User? GetUserByUsername(string username);
    User? GetUserByEmail(string email);
    public User Register(string username, string email, string password);
}