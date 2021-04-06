using api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{Id}")]
        public ActionResult<User> GetSelectedUser([FromRoute] int Id)
        {
            var user = _userService.GetUserWithSelectedId(Id);
            user.PasswordHash = null;
            return Ok(user);
        }
    }
}