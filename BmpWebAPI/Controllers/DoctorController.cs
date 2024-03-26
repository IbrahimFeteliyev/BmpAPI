
using Bmp.Business.Abstarct;
using Bmp.Entities.DTOs.DoctorDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Bmp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IWebHostEnvironment _env;

        public DoctorController(IDoctorService doctorService, IWebHostEnvironment env)
        {
            _doctorService = doctorService;
            _env = env;
        }

        [HttpGet("GetAllDoctors")]
        public IActionResult GetAllDoctors(string langCode)
        {
            var result = _doctorService.GetAllDoctors(langCode);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("CreateDoctor")]
        public async Task<IActionResult> CreateDoctor(DoctorAddDTO doctorAddDTO)
        {
            var result = await _doctorService.AddDoctorByLanguageAsync(doctorAddDTO, _env.WebRootPath);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpDelete("RemoveDoctorById/{id}")]
        public IActionResult RemoveDoctorById(int id)
        {
            var result = _doctorService.RemoveDoctor(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
