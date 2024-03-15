using Microsoft.AspNetCore.Http;


namespace Bmp.Entities.DTOs.AboutDTOs
{
    public class AboutAddDTO
    {
        public IFormFile PhotoUrl { get; set; }
        public List<string> Content { get; set; }
        public List<string> LangCode { get; set; }
    }
}
