using StockAPI.BusinessLogic.Interfaces;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace StockAPI.BusinessLogic.Services;

public class PasswordHashService : IPasswordHashService
{
    // Generate a random salt
    private static byte[] GenerateSalt(int size)
    {
        using var rng = RandomNumberGenerator.Create();
        var salt = new byte[size];
        rng.GetBytes(salt);
        return salt;
    }

    // Hash the password using SHA-256 and a random salt
    public string HashPassword(string password)
    {
        // Generate a random salt (you should store this with the hashed password)
        var salt = GenerateSalt(16);

        // Combine the password and salt, then hash using SHA-256
        using var sha256 = SHA256.Create();
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        var combinedBytes = new byte[passwordBytes.Length + salt.Length];

        Buffer.BlockCopy(passwordBytes, 0, combinedBytes, 0, passwordBytes.Length);
        Buffer.BlockCopy(salt, 0, combinedBytes, passwordBytes.Length, salt.Length);

        var hashedBytes = sha256.ComputeHash(combinedBytes);

        // Combine the salt and hashed password and convert to base64 for storage
        return Convert.ToBase64String(salt) + "|" + Convert.ToBase64String(hashedBytes);
    }

    // Verify if the provided password matches the stored hashed password
    public bool VerifyPassword(string password, string storedHash)
    {
        // Split the stored hash into salt and hashed password
        var parts = storedHash.Split('|');
        var storedSalt = Convert.FromBase64String(parts[0]);
        var storedHashedPassword = Convert.FromBase64String(parts[1]);

        // Combine the provided password and stored salt, then hash using SHA-256
        using var sha256 = SHA256.Create();
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        var combinedBytes = new byte[passwordBytes.Length + storedSalt.Length];

        Buffer.BlockCopy(passwordBytes, 0, combinedBytes, 0, passwordBytes.Length);
        Buffer.BlockCopy(storedSalt, 0, combinedBytes, passwordBytes.Length, storedSalt.Length);

        var hashedBytes = sha256.ComputeHash(combinedBytes);

        // Compare the calculated hash with the stored hash
        return StructuralComparisons.StructuralEqualityComparer.Equals(hashedBytes, storedHashedPassword);
    }
}
