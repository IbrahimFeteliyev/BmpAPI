using Bmp.Core.Entity;


namespace Bmp.Entities.Concrete
{
    public class HospitalBranch : BaseEntity, IEntity
    {
        public string CoverPhoto { get; set; }
        public List<HospitalBranchPhoto> HospitalBranchPhotos { get; set; } = new List<HospitalBranchPhoto>();
        public List<HospitalBranchLanguage> HospitalBranchLanguages { get; set; } = new List<HospitalBranchLanguage>();
        public List<HospitalBranchFeature> HospitalBranchFeatures { get; set; } = new List<HospitalBranchFeature>();
    }
}
