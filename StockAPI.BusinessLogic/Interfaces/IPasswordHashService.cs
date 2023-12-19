﻿namespace StockAPI.BusinessLogic.Interfaces;

public interface IPasswordHashService
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string storedHash);
}
