using API.Controllers;
using Application.Models.UserExam;
using Application.Services.UserExams;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace APITest
{
    public class Test
    {
        [Fact]
        public void UserExam_Test()
        {
            //Areange
            var moq = new Mock<IUserExamService>();

            ExamsController controller = new(moq.Object);

            AddUserExamDto exam = new()
            {
                Name = "Exam1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(5),
            };

            //Act
            var result = controller.Post(exam);

            //Assert
            Assert.IsType<CreatedResult>(result);
        }
    }
}