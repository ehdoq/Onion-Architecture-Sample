using Application.Models.UserExam;
using Application.Services.UserExams;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IUserExamService _userExamService;

        public ExamsController(IUserExamService userExamService)
        {
            _userExamService = userExamService;
        }

        private string? getCurrentUserMobile()
        {
            if (HttpContext.User.Claims.Any())
                return HttpContext.User.Claims.First().Value;

            return null;
        }

        [HttpPost("AddExam")]
        public IActionResult Post([FromBody] AddUserExamDto addUserExam)
        {
            var result = _userExamService.MakeExam(addUserExam, getCurrentUserMobile());
            return StatusCode(StatusCodes.Status201Created, result.Id);
        }

        [HttpGet("GetExam")]
        public IActionResult GetAll([FromQuery] string pageNumber = "1", string pageSize = "5")
        {
            var result = _userExamService.GetExam(int.Parse(pageNumber), int.Parse(pageSize), getCurrentUserMobile());
            return Ok(result);
        }

        [HttpPut("EditExam")]
        public IActionResult Update([FromBody] EditUserExamDto editModel)
        {
            var result = _userExamService.EditExam(editModel, getCurrentUserMobile());
            return Ok(result.Id);
        }

        [HttpDelete("DeleteExam")]
        public IActionResult Delete([FromQuery] int id)
        {
            var result = _userExamService.DeleteExam(id, getCurrentUserMobile());
            return Ok(result);
        }
    }
}