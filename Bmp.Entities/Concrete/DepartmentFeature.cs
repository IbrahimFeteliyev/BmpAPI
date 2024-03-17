using Bmp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.Concrete
{
    public class DepartmentFeature : BaseEntity, IEntity
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<DepartmentFeatureLanguage> DepartmentFeatureLanguages { get; set; } = new List<DepartmentFeatureLanguage>();
    }
}
