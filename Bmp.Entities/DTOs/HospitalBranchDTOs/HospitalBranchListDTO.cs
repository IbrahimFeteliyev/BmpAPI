

namespace Bmp.Entities.DTOs.HospitalBranchDTOs
{
    public class HospitalBranchListDTO
    {
        public int Id { get; set; }
        public string CoverPhoto { get; set; }
        public string BranchName { get; set; }
        public string Description { get; set; }

        public List<string> PhotoUrl { get; set; }
        public List<HospitalBranchFeatureListDTO> Features { get; set; }
    }
}
