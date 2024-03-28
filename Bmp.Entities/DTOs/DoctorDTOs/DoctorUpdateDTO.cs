using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.DTOs.DoctorDTOs
{
    public class DoctorUpdateDTO
    {
        public int Id { get; set; }
        public IFormFile? PhotoUrl { get; set; }
        public string ContactNumber { get; set; }
        public List<string> DoctorName { get; set; }
        public List<string> DoctorSurname { get; set; }
        public List<string> Specialty { get; set; }
        public int DepartmentId { get; set; }
        public int HospitalBranchId { get; set; }
        public List<DoctorEducationUpdateDTO> DoctorEducations { get; set; }
        public List<DoctorWorkExperienceUpdateDTO> DoctorWorkExperiences { get; set; }
    }

    public class DoctorEducationUpdateDTO
    {
        public List<string> EducationText { get; set; }
    }

    public class DoctorWorkExperienceUpdateDTO
    {
        public List<string> WorkExperienceText { get; set; }
    }
}
