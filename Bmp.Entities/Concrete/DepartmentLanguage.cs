using Bmp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.Concrete
{
    public class DepartmentLanguage : IEntity
    {
        public int Id { get; set; }
        public string LangCode { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
