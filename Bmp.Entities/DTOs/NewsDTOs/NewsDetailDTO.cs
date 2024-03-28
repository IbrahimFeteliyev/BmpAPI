namespace Bmp.Entities.DTOs.NewsDTOs
{
    public class NewsDetailDTO
    {
        public int Id { get; set; }
        public string CoverPhoto { get; set; }
        public List<string> MainTitle { get; set; }
        public List<string> MainContent { get; set; } 
        public List<string> PhotoUrl { get; set; }
        public List<NewsContentListDTO> Contents { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
