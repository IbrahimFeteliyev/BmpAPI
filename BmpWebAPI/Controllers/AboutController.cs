using Bmp.Business.Abstarct;
using Bmp.Entities.DTOs.AboutDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bmp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IWebHostEnvironment _env;

        public AboutController(IAboutService aboutService, IWebHostEnvironment env)
        {
            _aboutService = aboutService;
            _env = env;
        }

        [HttpGet("GetAllAbouts")]
        public IActionResult GetAllAbouts(string langCode)
        {
            var result = _aboutService.GetAllAboutsAdmin(langCode);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAbout")]
        public IActionResult GetAbout(string langCode)
        {
            var result = _aboutService.GetAboutAdmin(langCode);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("CreateAbout")]
        public async Task<IActionResult> CreateAbout(AboutAddDTO aboutAddDTO)
        {
            var result = await _aboutService.AddAboutByLanguageAsync(aboutAddDTO, _env.WebRootPath);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetAboutById/{id}")]
        public IActionResult GetAboutById(int id)
        {
            var result = _aboutService.GetAboutById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(int id, AboutAdminUpdateDTO aboutAddDTO)
        {
            var result = await _aboutService.UpdateAboutByLanguageAsync(id, aboutAddDTO, _env.WebRootPath);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("RemoveAboutById/{id}")]
        public IActionResult RemoveAboutById(int id)
        {
            var result = _aboutService.RemoveAbout(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
