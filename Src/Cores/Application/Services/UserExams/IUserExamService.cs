using Application.Models.UserExam;
using Domain.UserExams;

namespace Application.Services.UserExams
{
    public interface IUserExamService
    {
        UserExam MakeExam(AddUserExamDto addUserExam, string? currentUser);
        UserExam EditExam(EditUserExamDto editUserExam, string? currentUser);
        List<UserExamItem> GetExam(int pageNumber, int pageSize, string? currentUser);
        bool DeleteExam(long id, string? currentUser);
    }
}