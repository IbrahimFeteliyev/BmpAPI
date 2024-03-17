using Bmp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.Concrete
{
    public class DepartmentFeatureLanguage : IEntity
    {
        public int Id { get; set; }
        public string DepartmentFeatureText { get; set; }
        public string LangCode { get; set; }
        public int DepartmentFeatureId { get; set; }
        public DepartmentFeature DepartmentFeature { get; set; }
    }
}
