using DataLayer.SqlServer.Commons;
using Domain.UserExams;

namespace DataLayer.SqlServer.Repositories
{
    public class UserExamRepository : Repository<UserExam>, IUserExamRepository
    {
        public UserExamRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}