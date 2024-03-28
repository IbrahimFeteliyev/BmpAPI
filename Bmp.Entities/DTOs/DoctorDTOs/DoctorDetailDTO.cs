

namespace Bmp.Entities.DTOs.DoctorDTOs
{
    public class DoctorDetailDTO
    {
        public int Id { get; set; }
        public string ContactNumber { get; set; }
        public string PhotoUrl { get; set; }
        public List<string> DoctorName { get; set; }
        public List<string> DoctorSurname { get; set; }
        public List<string> Specialty { get; set; }
        public int DepartmentId { get; set; }
        public int HospitalBranchId { get; set; }
        public List<DoctorEducationListDTO> DoctorEducations { get; set; }
        public List<DoctorWorkExperienceListDTO> DoctorWorkExperiences { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
