namespace Bmp.Entities.DTOs.NewsDTOs
{
    public class NewsListDTO
    {
        public int Id { get; set; }
        public string CoverPhoto { get; set; }
        public string MainTitle { get; set; }
        public string MainContent { get; set; }

        public List<string> PhotoUrl { get; set; }
        public List<NewsContentListDTO> Contents { get; set; }
    }
}
