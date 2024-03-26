using Bmp.Core.Entity;


namespace Bmp.Entities.Concrete
{
    public class DoctorEducationLanguage : IEntity
    {
        public int Id { get; set; }
        public string EducationText { get; set; }
        public string LangCode { get; set; }
        public int DoctorEducationId { get; set; }
        public DoctorEducation DoctorEducation { get; set; }
    }
}
