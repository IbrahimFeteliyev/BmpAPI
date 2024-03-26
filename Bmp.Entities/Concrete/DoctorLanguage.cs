using Bmp.Core.Entity;


namespace Bmp.Entities.Concrete
{
    public class DoctorLanguage : IEntity
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string Specialty { get; set; }
        public string LangCode { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
