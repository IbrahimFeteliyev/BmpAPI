using Bmp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.Concrete
{
    public class Doctor :  BaseEntity, IEntity
    {
        
        public string ContactNumber { get; set; }
        public string PhotoUrl { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int HospitalBranchId { get; set; }
        public HospitalBranch HospitalBranch { get; set; }

        public List<DoctorEducation> DoctorEducations { get; set; } = new List<DoctorEducation>();
        public List<DoctorWorkExperience> DoctorWorkExperiences { get; set; } = new List<DoctorWorkExperience>();
        public List<DoctorLanguage> DoctorLanguages { get; set; } = new List<DoctorLanguage>();
    }
}
