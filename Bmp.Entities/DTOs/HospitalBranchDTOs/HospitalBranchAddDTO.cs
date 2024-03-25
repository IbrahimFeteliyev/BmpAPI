using Microsoft.AspNetCore.Http;

namespace Bmp.Entities.DTOs.HospitalBranchDTOs
{
    public class HospitalBranchAddDTO
    {
        public IFormFile CoverPhoto { get; set; }
        public string MapUrl { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAdress { get; set; }
        public List<string> BranchName { get; set; }
        public List<string> LangCode { get; set; }
        public List<string> Description { get; set; }

        public List<IFormFile> PhotoUrl { get; set; }

        public List<HospitalBranchFeatureAddDTO> HospitalBranchFeatures { get; set; }
    }

    public class HospitalBranchFeatureAddDTO
    {
        public string Count { get; set; }
        public List<string> FeatureDescription { get; set; }
        public IFormFile FeaturePhotoUrl { get; set; }
    }
}
