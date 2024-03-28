using Microsoft.AspNetCore.Http;

namespace Bmp.Entities.DTOs.BlogDTOs
{
    public class BlogAddDTO
    {
        public IFormFile CoverPhoto { get; set; }
        public List<string> MainTitle { get; set; }
        public List<string> MainContent { get; set; }
        public List<string> LangCode { get; set; }

        public List<IFormFile> PhotoUrl { get; set; }

        public List<BlogContentAddDTO> BlogContents { get; set; }
    }

    public class BlogContentAddDTO
    {
        public List<string> Title { get; set; }
        public List<string> Content { get; set; }
    }
}
