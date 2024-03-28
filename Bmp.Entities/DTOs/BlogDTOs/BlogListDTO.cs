using Bmp.Entities.DTOs.HospitalBranchDTOs;


namespace Bmp.Entities.DTOs.BlogDTOs
{
    public class BlogListDTO
    {
        public int Id { get; set; }
        public string CoverPhoto { get; set; }
        public string MainTitle { get; set; }
        public string MainContent { get; set; }

        public List<string> PhotoUrl { get; set; }
        public List<BlogContentListDTO> Contents { get; set; }
    }
}
