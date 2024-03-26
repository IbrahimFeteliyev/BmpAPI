using Microsoft.AspNetCore.Http;


namespace Bmp.Entities.DTOs.DoctorDTOs
{
    public class DoctorAddDTO
    {
        public string ContactNumber { get; set; }
        public IFormFile PhotoUrl { get; set; }
        public List<string> DoctorName { get; set; }
        public List<string> DoctorSurname { get; set; }
        public List<string> Specialty { get; set; }
        public List<string> LangCode { get; set; }
        public int DepartmentId { get; set; }
        public int HospitalBranchId { get; set; }
        public List<DoctorEducationAddDTO> DoctorEducations { get; set; }
        public List<DoctorWorkExperienceAddDTO> DoctorWorkExperiences { get; set; }

    }

    public class DoctorEducationAddDTO
    {
        public List<string> EducationText { get; set; }
    }
    public class DoctorWorkExperienceAddDTO
    {
        public List<string> WorkExperienceText { get; set; }
    }
}
