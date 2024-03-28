using Bmp.Business.Abstarct;
using Bmp.DataAccess.Concrete.EntityFramework;
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
            try
            {
                _userRoleManager.AddUserRole(userId, roleId);

            }
            catch (Exception e)
            {
                return BadRequest(new { status = 400, message = e });
            }
            return Ok("okey");
        }

        [HttpDelete("remove")]
        public IActionResult RemoveUserRole(int userId, int roleId)
        {
            try
            {
                _userRoleManager.RemoveUserRole(userId, roleId);

            }
            catch (Exception e)
            {
                return BadRequest(new { status = 400, message = e });
            }
            return Ok("okey");
        }
    }
}
