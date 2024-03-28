
using Bmp.Business.Abstarct;
using Bmp.Entities.DTOs.DoctorDTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(Roles = "Admin")]
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

        [HttpPut("UpdateDoctor/{Id}")]
        public async Task<IActionResult> UpdateDoctor(DoctorUpdateDTO doctorUpdateDTO)
        {
            var result = await _doctorService.UpdateDoctorByLanguageAsync(doctorUpdateDTO, _env.WebRootPath);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        
        [HttpGet("GetDoctorById/{id}")]
        public IActionResult GetDoctorById(int id)
        {
            var result = _doctorService.GetDoctorById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("GetDoctorLangById/{id}")]
        public IActionResult GetDoctorLangById(int id, string langCode)
        {
            var result = _doctorService.GetDoctorLangById(id, langCode);
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
