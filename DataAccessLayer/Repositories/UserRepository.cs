using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DbContext context) : base(context)
    {
    }
}