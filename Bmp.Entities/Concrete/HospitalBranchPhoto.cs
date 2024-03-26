using Bmp.Core.Entity;


namespace Bmp.Entities.Concrete
{
    public class HospitalBranchPhoto : BaseEntity, IEntity
    {
        public string PhotoUrl { get; set; }
        public int HospitalBranchId { get; set; }
        public HospitalBranch HospitalBranch { get; set; }
    }
}
