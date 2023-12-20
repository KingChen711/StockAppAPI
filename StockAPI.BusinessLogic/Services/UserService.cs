using StockAPI.BusinessLogic.Interfaces;
using StockAPI.DataAccess.Repositories.Interfaces;
using StockAPI.Models;

namespace StockAPI.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHashService _passwordHashService;

        public UserService(IUnitOfWork unitOfWork, IPasswordHashService passwordHashService)
        {
            _unitOfWork = unitOfWork;
            _passwordHashService = passwordHashService;
        }

        public User? GetUserByUsername(string username)
        {
            return _unitOfWork.UserRepository.FindOne(user => user.Username.Equals(username));
        }

        public User? GetUserByEmail(string email)
        {
            return _unitOfWork.UserRepository.FindOne(user => user.Email.Equals(email));
        }

        public User Register(string username, string email, string password)
        {
            var existingUserByUsername = GetUserByUsername(username);

            if (existingUserByUsername != null)
            {
                throw new ArgumentException("This username is already used!");
            }

            var emailLowerCase = email.ToLower();

            var existingUserByEmail = GetUserByEmail(emailLowerCase);

            if (existingUserByEmail != null)
            {
                throw new ArgumentException("This email is already used!");
            }

            var hashedPassword = _passwordHashService.HashPassword(password);

            _unitOfWork.UserRepository.Insert(new User() { Username = username, Email = emailLowerCase, HashedPassword = hashedPassword });
            _unitOfWork.Save();
            return _unitOfWork.UserRepository.FindOne(user => user.Email.Equals(emailLowerCase))!;
        }
    }
}
