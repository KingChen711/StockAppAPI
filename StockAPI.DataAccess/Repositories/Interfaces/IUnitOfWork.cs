namespace StockAPI.DataAccess.Repositories.Interfaces;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    void Save();
}