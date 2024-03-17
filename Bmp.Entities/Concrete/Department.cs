using Bmp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.Concrete
{
    public class Department : BaseEntity, IEntity
    {
        public string IconUrl { get; set; }
        public string PhotoUrl { get; set; }

        public List<DepartmentLanguage> DepartmentLanguages { get; set; } = new List<DepartmentLanguage>();
        public List<DepartmentFeature> DepartmentFeatures { get; set; } = new List<DepartmentFeature> { };
    }
}
