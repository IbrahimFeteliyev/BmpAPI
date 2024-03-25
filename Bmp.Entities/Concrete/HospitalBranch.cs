using Bmp.Core.Entity;


namespace Bmp.Entities.Concrete
{
    public class HospitalBranch : BaseEntity, IEntity
    {
        public string CoverPhoto { get; set; }
        public string MapUrl { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAdress { get; set; }
        public List<HospitalBranchPhoto> HospitalBranchPhotos { get; set; } = new List<HospitalBranchPhoto>();
        public List<HospitalBranchLanguage> HospitalBranchLanguages { get; set; } = new List<HospitalBranchLanguage>();
        public List<HospitalBranchFeature> HospitalBranchFeatures { get; set; } = new List<HospitalBranchFeature>();
    }
}
