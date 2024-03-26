using Bmp.Core.Entity;


namespace Bmp.Entities.Concrete
{
    public class DoctorWorkExperience : BaseEntity, IEntity
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public List<DoctorWorkExperienceLanguage> DoctorWorkExperienceLanguages { get; set; } = new List<DoctorWorkExperienceLanguage>();
    }
}
