namespace Application.Models.UserExam
{
    public class UserExamItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}