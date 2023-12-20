using StockAPI.Models;

namespace StockAPI.BusinessLogic.Interfaces;

public interface IUserService
{
    User? GetUserByUsername(string username);
    User? GetUserByEmail(string email);
    public RecordAccessToken Register(string username, string email, string password);
    public RecordAccessToken Login(string email, string password);
}