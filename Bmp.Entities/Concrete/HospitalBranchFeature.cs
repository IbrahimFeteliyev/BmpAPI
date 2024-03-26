using Bmp.Core.Entity;


namespace Bmp.Entities.Concrete
{
    public class HospitalBranchFeature : BaseEntity, IEntity
    {
        public string PhotoUrl { get; set; }
        public string Count { get; set; }
        public int HospitalBranchId { get; set; }
        public HospitalBranch HospitalBranch { get; set; }
        public List<HospitalBranchFeatureLanguage> HospitalBranchFeatureLanguages { get; set; } = new List<HospitalBranchFeatureLanguage>();
    }
}
