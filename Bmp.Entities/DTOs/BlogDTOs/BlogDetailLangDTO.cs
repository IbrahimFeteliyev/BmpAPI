

namespace Bmp.Entities.DTOs.BlogDTOs
{
    public class BlogDetailLangDTO
    {
        public int Id { get; set; }
        public string CoverPhoto { get; set; }
        public string MainTitle { get; set; }
        public string MainContent { get; set; }
        public List<string> PhotoUrls { get; set; }
        public List<BlogContentLangDTO> Contents { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public class BlogContentLangDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
