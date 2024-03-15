using Bmp.Business.Abstarct;
using Microsoft.AspNetCore.Mvc;

namespace Bmp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleManager _userRoleManager;
        public UserRoleController(IUserRoleManager userRoleManager)
        {
            _userRoleManager = userRoleManager;
        }

        [HttpPost("add")]
        public IActionResult AddUserRole(int userId, int roleId)
        {
            _userRoleManager.AddUserRole(userId, roleId);
            return Ok();
        }

        [HttpDelete("remove")]
        public IActionResult RemoveUserRole(int userId, int roleId)
        {
            _userRoleManager.RemoveUserRole(userId, roleId);
            return Ok();
        }
    }
}
