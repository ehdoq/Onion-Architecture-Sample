using DataLayer.SqlServer.Commons;
using Domain.Users;

namespace DataLayer.SqlServer.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }

        public User GetByMobile(string mobile)
        {
            return _dbContext.Users.SingleOrDefault(x => x.Mobile == mobile);    
        }
    }
}