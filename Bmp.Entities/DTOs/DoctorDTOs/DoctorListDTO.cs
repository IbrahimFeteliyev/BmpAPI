
namespace Bmp.Entities.DTOs.DoctorDTOs
{
    public class DoctorListDTO
    {
        public int Id { get; set; }
        public string ContactNumber { get; set; }
        public string PhotoUrl { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string Specialty { get; set; }
        public string DepartmentName { get; set; }
        public string HospitalBranchName { get; set; }
        public List<DoctorEducationListDTO> DoctorEducations { get; set; }
        public List<DoctorWorkExperienceListDTO> DoctorWorkExperiences { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

}
