using Microsoft.AspNetCore.Http;


namespace Bmp.Entities.DTOs.NewsDTOs
{
    public class NewsUpdateDTO
    {
        public int Id { get; set; }
        public IFormFile? CoverPhoto { get; set; }
        public List<string> MainTitle { get; set; }
        public List<string> MainContent { get; set; }
        public List<IFormFile>? PhotoUrl { get; set; }
        public List<NewsContentUpdateDTO> NewsContents { get; set; }
    }

    public class NewsContentUpdateDTO
    {
        public List<string> Title { get; set; }
        public List<string> Content { get; set; }

    }
}
