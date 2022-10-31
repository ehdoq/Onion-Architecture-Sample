using Application.Models.UserExam;
using Application.Services.Users;
using Domain.UserExams;

namespace Application.Services.UserExams
{
    public class UserExamService : IUserExamService
    {
        private readonly IUserExamRepository _examRepository;
        private readonly IUserService _userService;

        public UserExamService(IUserExamRepository examRepository, IUserService userService)
        {
            _examRepository = examRepository;
            _userService = userService;
        }

        public UserExam MakeExam(AddUserExamDto addUserExam, string? currentUser)
        {
            UserExam exam = new() 
            {
                Name = addUserExam.Name,
                User = _userService.GetUserByMobile(currentUser),
                StartDate = addUserExam.StartDate,
                EndDate = addUserExam.EndDate,
                CreatedDate = DateTime.Now,
            };

            _examRepository.Insert(exam);
            _examRepository.SaveChanges();

            return exam;
        }

        public UserExam EditExam(EditUserExamDto editUserExam, string? currentUser)
        {
            var exam = _examRepository.Get((int)editUserExam.Id);
            var user = _userService.GetUserByMobile(currentUser);

            if (exam.User.Id == user.Id)
            {
                exam.Name = editUserExam.Name;
                exam.EndDate = editUserExam.EndDate;
                exam.StartDate = editUserExam.StartDate;

                _examRepository.Update(exam);
                _examRepository.SaveChanges();
            }
            else
            {
                throw new UnauthorizedAccessException();
            }

            return exam;
        }

        public List<UserExamItem> GetExam(int pageNumber, int pageSize, string? currentUser)
        {
            var user = _userService.GetUserByMobile(currentUser);

            return _examRepository.GetQueryable().Where(u => u.User.Id == user.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(o => new UserExamItem
            {
                Id = o.Id,
                Name = o.Name,
                StartDate = o.StartDate,
                EndDate = o.EndDate
            }).ToList();
        }

        public bool DeleteExam(long id, string? currentUser)
        {
            var exam = _examRepository.Get((int)id);
            var user = _userService.GetUserByMobile(currentUser);

            if (exam.User.Id == user.Id)
            {
                exam.IsDeleted = true;

                _examRepository.Update(exam);
                _examRepository.SaveChanges();
            }
            else
            {
                throw new UnauthorizedAccessException();
            }

            return true;
        }
    }
}