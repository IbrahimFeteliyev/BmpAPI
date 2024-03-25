using Bmp.Business.Abstarct;
using Bmp.Entities.DTOs.ShortInfoDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Bmp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortInfoController : ControllerBase
    {
        private readonly IShortInfoService _shortInfoService;

        public ShortInfoController(IShortInfoService shortInfoService)
        {
            _shortInfoService = shortInfoService;
        }


        [HttpGet("GetAllShortInfos")]
        public IActionResult GetAllShortInfos(string langCode)
        {
            var result = _shortInfoService.GetAllShortInfosAdmin(langCode);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("CreateShortInfo")]
        public async Task<IActionResult> CreateShortInfo(ShortInfoAddDTO shortInfoAddDTO)
        {
            var result = await _shortInfoService.AddShortInfoByLanguageAsync(shortInfoAddDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("UpdateShortInfo/{id}")]
        public async Task<IActionResult> UpdateShortInfo(ShortInfoUpdateDTO shortInfoUpdateDTO, int id)
        {
            var result = await _shortInfoService.UpdateShortInfoByLanguageAsync(shortInfoUpdateDTO, id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetShortInfoById/{id}")]
        public IActionResult GetShortInfoById(int id)
        {
            var result = _shortInfoService.GetShortInfoById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpDelete("RemoveShortInfoById/{id}")]
        public IActionResult RemoveShortInfoById(int id)
        {
            var result = _shortInfoService.RemoveShortInfo(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
