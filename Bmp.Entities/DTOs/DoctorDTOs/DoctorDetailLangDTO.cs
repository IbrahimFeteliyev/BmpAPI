using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.DTOs.DoctorDTOs
{
    public class DoctorDetailLangDTO
    {
        public int Id { get; set; }
        public string ContactNumber { get; set; }
        public string PhotoUrl { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string Specialty { get; set; }
        public string DepartmentName { get; set; }
        public string BranchName { get; set; }
        public List<DoctorEducationLangDTO> DoctorEducations { get; set; }
        public List<DoctorWorkExperienceLangDTO> DoctorWorkExperiences { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
    public class DoctorEducationLangDTO
    {
        public string EducationText { get; set; }
    }
    public class DoctorWorkExperienceLangDTO
    {
        public string WorkExperienceText { get; set; }
    }
}
