

namespace Bmp.Entities.DTOs.HospitalBranchDTOs
{
    public class HospitalBranchDetailDTO
    {
        public int Id { get; set; }
        public string CoverPhoto { get; set; }
        public List<string> BranchName { get; set; }
        public List<string> Description { get; set; }
        public List<string> PhotoUrl { get; set; }
        public List<HospitalBranchFeatureListDTO> Features { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
