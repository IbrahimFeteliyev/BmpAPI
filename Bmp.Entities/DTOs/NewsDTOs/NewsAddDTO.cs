using Microsoft.AspNetCore.Http;

namespace Bmp.Entities.DTOs.NewsDTOs
{
    public class NewsAddDTO
    {
        public IFormFile CoverPhoto { get; set; }
        public List<string> MainTitle { get; set; }
        public List<string> MainContent { get; set; }
        public List<string> LangCode { get; set; }

        public List<IFormFile> PhotoUrl { get; set; }

        public List<NewsContentAddDTO> NewsContents { get; set; }
    }

    public class NewsContentAddDTO
    {
        public List<string> Title { get; set; }
        public List<string> Content { get; set; }
    }
}
