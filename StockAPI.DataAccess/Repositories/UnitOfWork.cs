using StockAPI.DataAccess.Data;
using StockAPI.DataAccess.Repositories.Interfaces;

namespace StockAPI.DataAccess.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly StockAppContext _db;
    public IUserRepository UserRepository { get; private set; }

    public UnitOfWork(StockAppContext db)
    {
        _db = db;
        UserRepository = new UserRepository(_db);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}

