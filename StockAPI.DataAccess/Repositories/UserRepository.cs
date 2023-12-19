
using Microsoft.EntityFrameworkCore;
using StockAPI.DataAccess.Repositories.Interfaces;
using StockAPI.Models;

namespace StockAPI.DataAccess.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
    }
}