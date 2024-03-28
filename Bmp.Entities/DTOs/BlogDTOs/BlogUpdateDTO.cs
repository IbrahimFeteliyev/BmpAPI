using Microsoft.AspNetCore.Http;


namespace Bmp.Entities.DTOs.BlogDTOs
{
    public class BlogUpdateDTO
    {
        public int Id { get; set; }
        public IFormFile? CoverPhoto { get; set; }
        public List<string> MainTitle { get; set; }
        public List<string> MainContent { get; set; }
        public List<IFormFile>? PhotoUrl { get; set; }
        public List<BlogContentUpdateDTO> BlogContents { get; set; }
    }

    public class BlogContentUpdateDTO
    {
        public List<string> Title { get; set; }
        public List<string> Content { get; set; }

    }
}
