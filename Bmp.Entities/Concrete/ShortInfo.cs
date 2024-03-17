using Bmp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.Concrete
{
    public class ShortInfo : BaseEntity, IEntity
    {
        public string Count { get; set; }
        public List<ShortInfoLanguage> ShortInfoLanguages { get; set; }
    }
}
