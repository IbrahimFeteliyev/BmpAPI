using Bmp.Business.Abstarct;
using Bmp.Entities.DTOs.HospitalBranchDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bmp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalBranchController : ControllerBase
    {
        private readonly IHospitalBranchService _hospitalBranchService;
        private readonly IWebHostEnvironment _env;

        public HospitalBranchController(IHospitalBranchService hospitalBranchService, IWebHostEnvironment env)
        {
            _hospitalBranchService = hospitalBranchService;
            _env = env;
        }

        [HttpGet("GetAllHospitalBranchs")]
        public IActionResult GetAllHospitalBranchs(string langCode)
        {
            var result = _hospitalBranchService.GetAllHospitalBranchs(langCode);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("CreateHospitalBranch")]
        public async Task<IActionResult> CreateHospitalBranch(HospitalBranchAddDTO hospitalBranchAddDTO)
        {
            var result = await _hospitalBranchService.AddHospitalBranchByLanguageAsync(hospitalBranchAddDTO, _env.WebRootPath);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPut("UpdateHospitalBranch/{Id}")]
        public async Task<IActionResult> UpdateHospitalBranch(HospitalBranchUpdateDTO hospitalBranchUpdateDTO)
        {
            var result = await _hospitalBranchService.UpdateHospitalBranchByLanguageAsync(hospitalBranchUpdateDTO, _env.WebRootPath);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("GetHospitalBranchById/{id}")]
        public IActionResult GetHospitalBranchById(int id)
        {
            var result = _hospitalBranchService.GetHospitalBranchById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpDelete("RemoveHospitalBranchById/{id}")]
        public IActionResult RemoveHospitalBranchById(int id)
        {
            var result = _hospitalBranchService.RemoveHospitalBranch(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
