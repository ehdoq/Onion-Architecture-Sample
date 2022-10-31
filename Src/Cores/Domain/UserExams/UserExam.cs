using Domain.Commons;
using Domain.Users;

namespace Domain.UserExams
{
    public class UserExam : BaseEntity
    {
        public string? Name { get; set; }
        public User? User { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}