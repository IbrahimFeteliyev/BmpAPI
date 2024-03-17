using Bmp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.Concrete
{
    public class DoctorWorkExperience : BaseEntity, IEntity
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public List<DoctorWorkExperienceLanguage> DoctorWorkExperienceLanguages { get; set; } = new List<DoctorWorkExperienceLanguage>();
    }
}
