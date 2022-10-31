using Domain.Commons;

namespace Domain.Users
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByMobile(string mobile);
    }
}