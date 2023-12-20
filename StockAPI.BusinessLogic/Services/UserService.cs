using StockAPI.BusinessLogic.Interfaces;
using StockAPI.DataAccess.Repositories.Interfaces;
using StockAPI.Models;

namespace StockAPI.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHashService _passwordHashService;
        private readonly IJwtService _jwtService;

        public UserService(IUnitOfWork unitOfWork, IPasswordHashService passwordHashService, IJwtService jwtService)
        {
            _unitOfWork = unitOfWork;
            _passwordHashService = passwordHashService;
            _jwtService = jwtService;
        }

        public User? GetUserByUsername(string username)
        {
            return _unitOfWork.UserRepository.FindOne(user => user.Username.Equals(username));
        }

        public User? GetUserByEmail(string email)
        {
            return _unitOfWork.UserRepository.FindOne(user => user.Email.Equals(email));
        }

        public RecordAccessToken Register(string username, string email, string password)
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

            var user = _unitOfWork.UserRepository.FindOne(user => user.Email.Equals(emailLowerCase))!;
            return ConvertUserToToken(user);
        }

        public RecordAccessToken Login(string usernameOrEmail, string password)
        {
            var existingUserByUsername = GetUserByUsername(usernameOrEmail);
            var existingUserByEmail = GetUserByEmail(usernameOrEmail.ToLower());

            if (existingUserByUsername == null && existingUserByEmail == null)
            {
                throw new ArgumentException("Username/Email or Password is not correct!");
            }

            var user = (existingUserByUsername ?? existingUserByEmail)!;

            var isCorrectPassword = _passwordHashService.VerifyPassword(password, user.HashedPassword);
            if (!isCorrectPassword)
            {
                throw new ArgumentException("Username/Email or Password is not correct!");
            }

            return ConvertUserToToken(user);
        }

        private RecordAccessToken ConvertUserToToken(User user)
        {
            return new RecordAccessToken(_jwtService.CreateToken(user.UserId, 30));
        }
    }
}


public record RecordAccessToken(string AccessToken);