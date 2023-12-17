using DataAccessLayer.Models;

namespace BusinessLogicLayer.Interfaces;

public interface IUserService
{
    User? GetUserByUsername(string username);
    User? GetUserByEmail(string email);
}