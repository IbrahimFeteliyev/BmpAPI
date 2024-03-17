using Bmp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.Concrete
{
    public class DoctorEducationLanguage : IEntity
    {
        public int Id { get; set; }
        public string EducationText { get; set; }
        public string LangCode { get; set; }
        public int DoctorEducationId { get; set; }
        public DoctorEducation DoctorEducation { get; set; }
    }
}
