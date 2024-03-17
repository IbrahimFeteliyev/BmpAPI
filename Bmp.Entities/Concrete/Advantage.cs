using Bmp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmp.Entities.Concrete
{
    public class Advantage : BaseEntity, IEntity
    {
        public string PhotoUrl { get; set; }
        public List<AdvantageLanguage> AdvantageLanguages { get; set; }
    }
}
