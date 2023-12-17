using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordHashService _passwordHashService;

        public UserService(IUserRepository userRepository, IPasswordHashService passwordHashService)
        {
            _repository = userRepository;
            _passwordHashService = passwordHashService;
        }

        public User? GetUserByUsername(string username)
        {
            return _repository.FindOne(user => user.Username.Equals(username));
        }

        public User? GetUserByEmail(string email)
        {
            return _repository.FindOne(user => user.Username.Equals(email));
        }

        public void Register(string username, string email, string password)
        {
            var existingUserByUsername = GetUserByUsername(username);

            if (existingUserByUsername != null)
            {
                throw new ArgumentException("This username is already used!");
            }

            var existingUserByEmail = GetUserByEmail(email);

            if (existingUserByEmail != null)
            {
                throw new ArgumentException("This email is already used!");
            }

            var hashedPassword = _passwordHashService.HashPassword(password);

            _repository.Insert(new User() { Username = username, Email = email, HashedPassword = hashedPassword });
        }
    }
}
