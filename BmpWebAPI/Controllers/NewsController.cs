using Bmp.Business.Abstarct;
using Bmp.Entities.DTOs.NewsDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bmp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        private readonly IWebHostEnvironment _env;

        public NewsController(INewsService newsService, IWebHostEnvironment env)
        {
            _newsService = newsService;
            _env = env;
        }

        [HttpGet("GetAllNewss")]
        public IActionResult GetAllNewss(string langCode)
        {
            var result = _newsService.GetAllNewss(langCode);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("CreateNews")]
        public async Task<IActionResult> CreateNews(NewsAddDTO newsAddDTO)
        {
            var result = await _newsService.AddNewsByLanguageAsync(newsAddDTO, _env.WebRootPath);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPut("UpdateNews/{Id}")]
        public async Task<IActionResult> UpdateNews(NewsUpdateDTO newsUpdateDTO)
        {
            var result = await _newsService.UpdateNewsByLanguageAsync(newsUpdateDTO, _env.WebRootPath);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


        [HttpGet("GetNewsById/{id}")]
        public IActionResult GetNewsById(int id)
        {
            var result = _newsService.GetNewsById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("GetNewsLangById/{id}")]
        public IActionResult GetNewsLangById(int id, string langCode)
        {
            var result = _newsService.GetNewsLangById(id, langCode);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpDelete("RemoveNewsById/{id}")]
        public IActionResult RemoveNewsById(int id)
        {
            var result = _newsService.RemoveNews(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
