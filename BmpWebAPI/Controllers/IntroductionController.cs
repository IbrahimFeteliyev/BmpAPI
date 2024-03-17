using Bmp.Business.Abstarct;
using Bmp.Entities.DTOs.IntroductionDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Bmp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntroductionController : ControllerBase
    {
        private readonly IIntroductionService _introductionService;
        private readonly IWebHostEnvironment _env;

        public IntroductionController(IIntroductionService introductionService, IWebHostEnvironment env)
        {
            _introductionService = introductionService;
            _env = env;
        }


        [HttpGet]
        public IActionResult GetIntroduction(string langCode)
        {
            var result = _introductionService.GetIntroductionAdmin(langCode);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("CreateIntroduction")]
        public async Task<IActionResult> CreateIntroduction(IntroductionAddDTO introductionAddDTO)
        {
            var result = await _introductionService.AddIntroductionByLanguageAsync(introductionAddDTO, _env.WebRootPath);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetIntroductionById/{id}")]
        public IActionResult GetIntroductionById(int id)
        {
            var result = _introductionService.GetIntroductionById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("UpdateIntroduction/{id}")]
        public async Task<IActionResult> UpdateIntroduction(int id, IntroductionAdminUpdateDTO introductionAddDTO)
        {
            var result = await _introductionService.UpdateIntroductionByLanguageAsync(id, introductionAddDTO, _env.WebRootPath);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("RemoveIntroductionById/{id}")]
        public IActionResult RemoveIntroductionById(int id)
        {
            var result = _introductionService.RemoveIntroduction(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
