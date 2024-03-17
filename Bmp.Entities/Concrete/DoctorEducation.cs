using Bmp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.Concrete
{
    public class DoctorEducation : BaseEntity, IEntity
    {
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public List<DoctorEducationLanguage> DoctorEducationLanguages { get; set; } = new List<DoctorEducationLanguage>();
    }
}
