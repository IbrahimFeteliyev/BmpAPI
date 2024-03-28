using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.DTOs.HospitalBranchDTOs
{
    public class HospitalBranchDetailLangDTO
    {
        public int Id { get; set; }
        public string CoverPhoto { get; set; }
        public string MapUrl { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAdress { get; set; }
        public string BranchName { get; set; }
        public string Description { get; set; }
        public List<string> PhotoUrls { get; set; }
        public List<HospitalBranchFeatureLangDTO> Features { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public class HospitalBranchFeatureLangDTO
    {
        public string Count { get; set; }
        public string FeatureDescription { get; set; }
        public string FeaturePhotoUrl { get; set; }
    }
}
