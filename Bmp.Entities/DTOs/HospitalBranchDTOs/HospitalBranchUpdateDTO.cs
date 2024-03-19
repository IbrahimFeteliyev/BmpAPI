using Microsoft.AspNetCore.Http;

namespace Bmp.Entities.DTOs.HospitalBranchDTOs
{
    public class HospitalBranchUpdateDTO
    {
        public int Id { get; set; }
        public IFormFile CoverPhoto { get; set; }
        public List<string> BranchName { get; set; }
        public List<string> Description { get; set; }
        public List<IFormFile> PhotoUrl { get; set; }
        public List<HospitalBranchFeatureUpdateDTO> HospitalBranchFeatures { get; set; }
    }

    public class HospitalBranchFeatureUpdateDTO
    {
        public string Count { get; set; }
        public List<string> FeatureDescription { get; set; }
        public IFormFile FeaturePhotoUrl { get; set; }
    }
}
