using Bmp.Business.Abstarct;
using Bmp.Entities.DTOs.MapDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bmp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private readonly IMapService _MapService;

        public MapController(IMapService MapService)
        {
            _MapService = MapService;
        }

        [HttpGet("GetAllMaps")]
        public IActionResult GetAllMapsAdmin()
        {
            var result = _MapService.GetAllMapsAdmin();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("CreateMap")]
        public async Task<IActionResult> CreateMap(MapDTO MapDTO)
        {
            var result = await _MapService.AddMapAsync(MapDTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("GetMapAdminById/{id}")]
        public IActionResult GetMapAdminById(int id)
        {
            var result = _MapService.GetMapAdminById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPut("UpdateMap/{id}")]
        public async Task<IActionResult> UpdateMap(MapDTO MapDTO , int id)
        {
            var result = await _MapService.UpdateMapAsync(MapDTO, id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("RemoveMapById/{id}")]
        public IActionResult RemoveMapById(int id)
        {
            var result = _MapService.RemoveMap(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
