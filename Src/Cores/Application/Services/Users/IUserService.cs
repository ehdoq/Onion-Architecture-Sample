using Application.Models.User;
using Domain.Users;

namespace Application.Services.Users
{
    public interface IUserService
    {
        User Register(AddUserDto addUserDto);
        bool Login(LoginUserDto loginUserDto);
    }
}