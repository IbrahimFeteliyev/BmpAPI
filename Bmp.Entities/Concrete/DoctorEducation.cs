using Bmp.Core.Entity;


namespace Bmp.Entities.Concrete
{
    public class DoctorEducation : BaseEntity, IEntity
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public List<DoctorEducationLanguage> DoctorEducationLanguages { get; set; } = new List<DoctorEducationLanguage>();
    }
}
