using Bmp.Business.Abstarct;
using Bmp.Entities.DTOs.DepartmentDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Bmp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IWebHostEnvironment _env;

        public DepartmentController(IDepartmentService departmentService, IWebHostEnvironment env)
        {
            _departmentService = departmentService;
            _env = env;
        }

        [HttpGet("GetAllDepartments")]
        public IActionResult GetAllDepartments(string langCode)
        {
            var result = _departmentService.GetAllDepartments(langCode);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetDepartmentById/{id}")]
        public IActionResult GetDepartmentById(int id)
        {
            var result = _departmentService.GetDepartmentById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("CreateDepartment")]
        public async Task<IActionResult> CreateDepartment(DepartmentAddDTO departmentAddDTO)
        {
            var result = await _departmentService.AddDepartmentByLanguageAsync(departmentAddDTO, _env.WebRootPath);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPut("UpdateDepartment/{id}")]
        public async Task<IActionResult> UpdateDepartment(DepartmentUpdateDTO departmentUpdateDTO)
        {
            var result = await _departmentService.UpdateDepartmentByLanguageAsync(departmentUpdateDTO, _env.WebRootPath);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


        [HttpDelete("RemoveDepartmentById/{id}")]
        public IActionResult RemoveDepartmentById(int id)
        {
            var result = _departmentService.RemoveDepartment(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
