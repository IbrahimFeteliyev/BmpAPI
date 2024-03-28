namespace Bmp.Entities.DTOs.NewsDTOs
{
    public class NewsDetailLangDTO
    {
        public int Id { get; set; }
        public string CoverPhoto { get; set; }
        public string MainTitle { get; set; }
        public string MainContent { get; set; }
        public List<string> PhotoUrls { get; set; }
        public List<NewsContentLangDTO> Contents { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public class NewsContentLangDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
