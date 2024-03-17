using Bmp.Business.Abstarct;
using Bmp.Entities.DTOs.AdvantageDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Bmp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvantageController : ControllerBase
    {
        private readonly IAdvantageService _advantageService;
        private readonly IWebHostEnvironment _env;

        public AdvantageController(IAdvantageService advantageService, IWebHostEnvironment env)
        {
            _advantageService = advantageService;
            _env = env;
        }

        [HttpGet("GetAllAdvantages")]
        public IActionResult GetAdvantages(string langCode)
        {
            var result = _advantageService.GetAllAdvantagesAdmin(langCode);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("CreateAdvantage")]
        public async Task<IActionResult> CreateAdvantage(AdvantageAddDTO advantageAddDTO)
        {
            var result = await _advantageService.AddAdvantageByLanguageAsync(advantageAddDTO, _env.WebRootPath);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetAdvantageById/{id}")]
        public IActionResult GetAdvantageById(int id)
        {
            var result = _advantageService.GetAdvantageById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPut("UpdateAdvantage/{id}")]
        public async Task<IActionResult> Updateadvantage(int id, AdvantageAdminUpdateDTO advantageAddDTO)
        {
            var result = await _advantageService.UpdateAdvantageByLanguageAsync(id, advantageAddDTO, _env.WebRootPath);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("RemoveAdvantageById/{id}")]
        public IActionResult RemoveadvantageById(int id)
        {
            var result = _advantageService.RemoveAdvantage(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
