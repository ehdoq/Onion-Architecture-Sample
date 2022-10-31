using Application.Models.User;
using Application.Security;
using Domain.Users;

namespace Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Register(AddUserDto addUserDto)
        {
            var hashPassword = SecurePasswordHasher.Hash(addUserDto.Password);

            var user = new User()
            {
                Mobile = addUserDto.Mobile,
                Name = addUserDto.Name,
                Password = hashPassword
            };

            _userRepository.Insert(user);
            _userRepository.SaveChanges();

            return user;
        }

        public bool Login(LoginUserDto loginUserDto)
        {
            var user = _userRepository.GetByMobile(loginUserDto.Mobile);

            if (user != null)
                return SecurePasswordHasher.Verify(loginUserDto.Password, user.Password);

            return false;
        }
    }
}