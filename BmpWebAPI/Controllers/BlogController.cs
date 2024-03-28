using Bmp.Business.Abstarct;
using Bmp.Entities.DTOs.BlogDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Bmp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IWebHostEnvironment _env;

        public BlogController(IBlogService blogService, IWebHostEnvironment env)
        {
            _blogService = blogService;
            _env = env;
        }

        [HttpGet("GetAllBlogs")]
        public IActionResult GetAllBlogs(string langCode)
        {
            var result = _blogService.GetAllBlogs(langCode);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("CreateBlog")]
        public async Task<IActionResult> CreateBlog(BlogAddDTO blogAddDTO)
        {
            var result = await _blogService.AddBlogByLanguageAsync(blogAddDTO, _env.WebRootPath);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPut("UpdateBlog/{Id}")]
        public async Task<IActionResult> UpdateBlog(BlogUpdateDTO blogUpdateDTO)
        {
            var result = await _blogService.UpdateBlogByLanguageAsync(blogUpdateDTO, _env.WebRootPath);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


        [HttpGet("GetBlogById/{id}")]
        public IActionResult GetBlogById(int id)
        {
            var result = _blogService.GetBlogById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("GetBlogLangById/{id}")]
        public IActionResult GetBlogLangById(int id, string langCode)
        {
            var result = _blogService.GetBlogLangById(id, langCode);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpDelete("RemoveBlogById/{id}")]
        public IActionResult RemoveBlogById(int id)
        {
            var result = _blogService.RemoveBlog(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
