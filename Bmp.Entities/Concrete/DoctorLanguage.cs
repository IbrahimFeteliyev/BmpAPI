using Bmp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.Concrete
{
    public class DoctorLanguage : IEntity
    {
        public int Id { get; set; }
        public string Specialty { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
