using Bmp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.Concrete
{
    public class DoctorWorkExperienceLanguage : IEntity
    {
        public int Id { get; set; }
        public string WorkExperienceText { get; set; }
        public string LangCode { get; set; }
        public int DoctorWorkExperienceId { get; set; }
        public DoctorWorkExperience DoctorWorkExperience { get; set; }
    }
}
