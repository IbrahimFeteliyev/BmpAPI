

namespace Bmp.Entities.DTOs.HospitalBranchDTOs
{
    public class HospitalBranchListDTO
    {
        public int Id { get; set; }
        public string MapUrl { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAdress { get; set; }
        public string CoverPhoto { get; set; }
        public string BranchName { get; set; }
        public string Description { get; set; }

        public List<string> PhotoUrl { get; set; }
        public List<HospitalBranchFeatureListDTO> Features { get; set; }
    }
}
